using System;
using System.IO;
using System.Linq;
using System.Text;
using Autofac;
using PSharp.Template.Core.Extensions;
using PSharp.Template.Core.Options;
using PSharp.Template.Jiguang.Extensions;
using PSharp.Template.Systems.AuthHelper;
using PSharp.Template.UnitOfWork;
using PSharp.Template.UnitOfWork.MySql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Util.Datas.Ef;
using Util.Logs.Extensions;
using Util.Webs.Extensions;
using Senparc.CO2NET;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.RegisterServices;
using Microsoft.Extensions.Hosting;

namespace PSharp.Template.ApiHost
{
    public class Startup
    {
        /// <summary>
        /// 初始化启动配置
        /// </summary>
        /// <param name="configuration">配置</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPSharp();
            services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter("Permission"));
                options.SuppressAsyncSuffixInActionNames = false;//不禁止action name的async后缀
            }).AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                });


            services.AddUnitOfWork<IDefaultUnitOfWork, InquiryUnitOfWork>(Configuration.GetConnectionString("MySqlConnection"));

            #region 认证

            JwtOptions jwtOptions = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
            services.AddAuthorization(options =>
                {
                    //options.AddPolicy("Admin",policy=> policy.RequireRole("Admin"));
                    options.AddPolicy("Permission", policy => policy.Requirements.Add(new PermissionRequirement()));
                })
                .AddAuthentication(t =>
                {
                    t.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
                    t.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(option=>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        SaveSigninToken = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = jwtOptions.Audience,
                        ValidIssuer = jwtOptions.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
                    };
                });

            #endregion

            #region swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Systems", new OpenApiInfo { Title = "权限模块", Version = "v1" });
                c.SwaggerDoc("Common", new OpenApiInfo { Title = "公共模块", Version = "v1" });
                c.SwaggerDoc("Business", new OpenApiInfo { Title = "业务模块", Version = "v1" });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Inquiry Api", Version = "v1" });

                c.ResolveConflictingActions(api=>api.First());

                #region Doc注释

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Util.Webs.xml"), true);
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PSharp.Template.Common.xml"), true);
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PSharp.Template.Systems.xml"), true);
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PSharp.Template.Business.xml"), true);

                #endregion

                #region 添加认证
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"}
                        },new string[] { }
                    }
                });
                #endregion
            });

            #endregion

            #region 微信

            services.AddSenparcGlobalServices(Configuration)
                .AddSenparcWeixinServices(Configuration);

            #endregion
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.AddPSharpDepenDency();
        }

        /// <summary>
        /// 配置开发环境请求管道
        /// </summary>
        public void ConfigureDevelopment(IApplicationBuilder app, IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            app.UseDeveloperExceptionPage();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/Systems/swagger.json", "权限模块");
                c.SwaggerEndpoint("/swagger/Common/swagger.json", "公共模块");
                c.SwaggerEndpoint("/swagger/Business/swagger.json", "业务模块");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "api");
            });

            CommonConfig(app, senparcSetting, senparcWeixinSetting);
        }

        /// <summary>
        /// 配置生产环境请求管道
        /// </summary>
        public void ConfigureProduction(IApplicationBuilder app, IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
            CommonConfig(app, senparcSetting, senparcWeixinSetting);
        }

        /// <summary>
        /// 公共配置
        /// </summary>
        private void CommonConfig(IApplicationBuilder app, IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            app.UseErrorLog();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            ConfigRoute(app);
            app.UsePSharp();

            #region 微信配置

            IRegisterService register = RegisterService.Start(senparcSetting.Value)
                .UseSenparcGlobal(false, null);
            register.UseSenparcWeixin(senparcWeixinSetting.Value, senparcSetting.Value);
            AccessTokenContainer.RegisterAsync(senparcWeixinSetting.Value.WeixinAppId, senparcWeixinSetting.Value.WeixinAppSecret);

            #endregion
        }


        /// <summary>
        /// 路由配置,支持区域
        /// </summary>
        private void ConfigRoute(IApplicationBuilder app)
        {
            app.UseOptions();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
