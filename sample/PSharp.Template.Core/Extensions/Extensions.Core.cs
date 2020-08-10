using Autofac;
using PSharp.Template.Core.Caches;
using PSharp.Template.Core.Dependency;
using PSharp.Template.Core.Files;
using PSharp.Template.Core.Files.Paths;
using PSharp.Template.Core.Middleware;
using PSharp.Template.Core.Options;
using PSharp.Template.Core.Packs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Files;
using Util.Files.Paths;
using Util.Logs.Extensions;
using Util.Randoms;
using Util.Reflections;
using IFileStore = Util.Files.IFileStore;
using System;
using PSharp.Template.Core.Datas.DbStrategy;

namespace PSharp.Template.Core.Extensions
{
    public static partial class Extensions
    {
        public static void AddPSharp(this IServiceCollection services)
        {
            services.AddNLog();

            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<DbOptions>(configuration.GetSection("DbOptions"));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            #region 主从策略配置

            DbOptions dbOptions = configuration.GetSection("DbOptions").Get<DbOptions>();
            Type type = Type.GetType(dbOptions.Strategy);
            if (type != null)
            {
                var dbStrategyClass = Activator.CreateInstance(type);
                services.AddSingleton(typeof(IDbStrategy), dbStrategyClass);
            }
            else
            {
                services.AddSingleton<IDbStrategy, PollingStrategy>();
            }

            #endregion

            #region 上传

            services.AddSingleton<IFileStore, DefaultFileStore>();
            services.AddSingleton<Files.IFileStore, FileStore>();
            services.AddSingleton<IPathGenerator, PSharpPathGenerator>();
            services.AddSingleton<IRandomGenerator, GuidRandomGenerator>();
            services.AddSingleton<IBasePath>(t => new DefaultBasePath("upload"));

            #endregion

            #region 缓存

            services.AddMemoryCache();
            services.TryAddScoped<ICache, CacheManager>();
            services.AddEasyCaching(o =>
            {
                o.UseInMemory("default");
            });

            #endregion

            IPsharpPackManager manager = new PsharpPackManager();
            manager.LoadPacks(services, configuration);
        }

        public static void AddPSharpDepenDency(this ContainerBuilder builder)
        {
            IFind finder = new Finder();
            var assemblies = finder.GetAssemblies();
            var scope = finder.Find(typeof(IIScopeDependency), assemblies).ToArray();
            var single = finder.Find(typeof(IISingletonDependency), assemblies).ToArray();
            var transient = finder.Find(typeof(IITransientDependency), assemblies).ToArray();

            builder.RegisterTypes(scope).AsSelf().PropertiesAutowired().InstancePerLifetimeScope();
            builder.RegisterTypes(single).AsSelf().PropertiesAutowired().SingleInstance();
            builder.RegisterTypes(transient).AsSelf().PropertiesAutowired().InstancePerDependency();
        }

        public static void UsePSharp(this IApplicationBuilder builder)
        {
            IPsharpPackManager manager = new PsharpPackManager();
            manager.UsePack(builder);
        }

        public static IApplicationBuilder UseOptions(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OptionsMiddleware>();
        }
    }
}
