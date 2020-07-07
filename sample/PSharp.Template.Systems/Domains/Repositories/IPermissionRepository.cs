using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Domains.Repositories;
using Util.Domains.Trees;
using PSharp.Template.Systems.Domains.Models;

namespace PSharp.Template.Systems.Domains.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IPermissionRepository : IRepository<Permission>
    {
        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="roleId"></param>
        /// <param name="resourceIds"></param>
        /// <param name="isDeny"></param>
        /// <returns></returns>
        Task SaveAsync(Guid applicationId, Guid roleId, List<Guid> resourceIds, bool isDeny);

        /// <summary>
        /// 保存接口权限
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="roleId"></param>
        /// <param name="codes"></param>
        /// <returns></returns>
        Task SaveInterfaceAsync(Guid applicationId, Guid roleId, List<string> codes);

        /// <summary>
        /// 获取资源标识列表
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="roleId"></param>
        /// <param name="isDeny"></param>
        /// <returns></returns>
        Task<List<Guid>> GetResourceIdsAsync(Guid applicationId, Guid roleId, bool isDeny);

        /// <summary>
        /// 获取接口code列表
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<string>> GetInterfaceCodesAsync(Guid applicationId, Guid roleId);

        /// <summary>
        /// 获取所有接口权限
        /// </summary>
        /// <returns></returns>
        List<RoleInterface> GetAllRoleInterface();
    }
}