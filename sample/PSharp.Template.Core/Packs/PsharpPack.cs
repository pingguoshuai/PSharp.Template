using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PSharp.Template.Core.Packs
{
    public abstract class PsharpPack
    {
        /// <summary>
        /// 将模块服务添加到依赖注入服务容器中
        /// </summary>
        /// <param name="services">依赖注入服务容器</param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public virtual IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        /// <summary>
        /// 应用模块服务
        /// </summary>
        /// <param name="provider">服务提供者</param>
        public virtual void UsePack(IApplicationBuilder provider)
        {
            
        }
    }
}
