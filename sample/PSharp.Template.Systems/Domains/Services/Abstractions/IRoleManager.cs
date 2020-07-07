using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PSharp.Template.Systems.Domains.Models;
using Util.Domains.Services;

namespace PSharp.Template.Systems.Domains.Services.Abstractions
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public interface IRoleManager : IDomainService
    {
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="role">角色</param>
        Task CreateAsync(Role role);
        /// <summary>
        /// 修改角色
        /// </summary>
        Task UpdateAsync(Role role);
        /// <summary>
        /// 添加用户到角色
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <param name="userIds">用户标识列表</param>
        Task AddUsersToRoleAsync(Guid roleId, List<Guid> userIds);
        /// <summary>
        /// 从角色移除用户
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <param name="userIds">用户标识列表</param>
        Task RemoveUsersFromRoleAsync(Guid roleId, List<Guid> userIds);
    }
}
