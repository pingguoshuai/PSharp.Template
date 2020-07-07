using System.Threading.Tasks;
using Util.Domains.Repositories;
using PSharp.Template.Systems.Domains.Models;
using Util.Aspects;

namespace PSharp.Template.Systems.Domains.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IApplicationRepository : IRepository<Application>
    {
        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<Application> GetByCodeAsync([NotEmpty]string code);
    }
}