using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using System;
using System.Threading.Tasks;
using PSharp.Template.Systems.Services.Dtos;
using Util.Datas.Ef.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PSharp.Template.Systems.Datas.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApplicationRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<Application> GetByCodeAsync(string code)
        {
            return await Set.SingleAsync(t => t.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
        }
    }
}