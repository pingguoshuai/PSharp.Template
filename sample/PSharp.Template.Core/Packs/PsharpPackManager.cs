using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Util.Reflections;

namespace PSharp.Template.Core.Packs
{
    /// <summary>
    /// 模块管理：自动加载服务注册
    /// </summary>
    public class PsharpPackManager : IPsharpPackManager
    {
        public IServiceCollection LoadPacks(IServiceCollection services, IConfiguration configuration)
        {
            IFind finder = new Finder();
            var assemblies = finder.GetAssemblies();

            Type[] packTypes = finder.Find(typeof(PsharpPack), assemblies).ToArray();
            foreach (var packType in packTypes)
            {
                PsharpPack pack = (PsharpPack)Activator.CreateInstance(packType);
                pack.AddServices(services, configuration);
            }
            return services;
        }

        public void UsePack(IApplicationBuilder app)
        {
            IFind finder = new Finder();
            var assemblies = finder.GetAssemblies();

            Type[] packTypes = finder.Find(typeof(PsharpPack), assemblies).ToArray();
            foreach (var packType in packTypes)
            {
                PsharpPack pack = (PsharpPack)Activator.CreateInstance(packType);
                pack.UsePack(app);
            }
        }
    }
}
