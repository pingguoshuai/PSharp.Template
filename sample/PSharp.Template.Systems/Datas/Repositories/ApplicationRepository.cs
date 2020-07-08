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
        private readonly IDefaultUnitOfWork _unitOfWork;

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApplicationRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork )
        {
            _unitOfWork = unitOfWork;
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

        /// <summary>
        /// 是否允许创建应用程序
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> CanCreateAsync(Application entity)
        {
            var exists = await ExistsAsync(t => t.Code.Equals(entity.Code, StringComparison.OrdinalIgnoreCase));
            return exists == false;
        }

        /// <summary>
        /// 是否允许修改应用程序
        /// </summary>
        /// <param name="entity">应用程序</param>
        public async Task<bool> CanUpdateAsync(Application entity)
        {
            var exists = await ExistsAsync(t => t.Id != entity.Id && t.Code == entity.Code);
            return exists == false;
        }
    }
}