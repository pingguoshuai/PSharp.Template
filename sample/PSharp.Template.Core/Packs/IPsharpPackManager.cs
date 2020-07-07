using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PSharp.Template.Core.Packs
{
    public interface IPsharpPackManager
    {
        /// <summary>
        /// 加载模块服务
        /// </summary>
        /// <param name="services">服务容器</param>
        /// <param name="configuration"></param>
        /// <returns>服务容器</returns>
        IServiceCollection LoadPacks(IServiceCollection services, IConfiguration configuration);

        /// <summary>
        /// 应用模块服务
        /// </summary>
        /// <param name="provider">服务提供者</param>
        void UsePack(IApplicationBuilder provider);
    }
}
