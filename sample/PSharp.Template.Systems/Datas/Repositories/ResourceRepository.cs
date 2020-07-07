using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Systems.Datas.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public class ResourceRepository : TreeRepositoryBase<Resource>, IResourceRepository {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ResourceRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="roleIds">角色标识列表</param>
        /// <returns></returns>
        public async Task<List<Resource>> GetMenusAsync(List<Guid> roleIds)
        {
            if (roleIds == null || roleIds.Count == 0)
                return new List<Resource>();
            var result = await
                (from module in Set
                    join permission in UnitOfWork.Set<Permission>() on module.Id equals permission.ResourceId
                    where module.Type == Domains.Enums.ResourceType.Menu &&
                          module.Enabled &&
                          roleIds.Contains(permission.RoleId)
                    select module).ToListAsync();
            return result.Distinct().OrderBy(t => t.SortId).ToList();
        }
    }
}
