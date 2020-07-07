using PSharp.Template.Core.Describers;
using PSharp.Template.Core.Extensions;
using PSharp.Template.Core.Options;
using PSharp.Template.Core.Packs;
using PSharp.Template.Systems.AuthHelper;
using PSharp.Template.Systems.Datas.Repositories;
using PSharp.Template.Systems.Domains.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PSharp.Template.Systems
{
    public class SystemsPack : PsharpPack
    {
        public override IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));

            var permissionOptions = new PermissionOptions();
            //setupAction?.Invoke(permissionOptions);
            services.AddIdentity<User, Role>(options => options.Load(permissionOptions))
                .AddUserStore<UserRepository>()
                .AddRoleStore<RoleRepository>()
                .AddDefaultTokenProviders();
            services.AddScoped<IdentityErrorDescriber, IdentityErrorChineseDescriber>();
            services.AddLogging();
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            return services;
        }
    }
}
