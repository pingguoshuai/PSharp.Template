using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSharp.Template.Core;
using PSharp.Template.Core.Extensions;
using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.Systems.Domains.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Util;
using Util.Domains.Services;
using Util.Exceptions;

namespace PSharp.Template.Systems.Domains.Services.Implements
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class RoleManager : DomainServiceBase, IRoleManager
    {
        /// <summary>
        /// 初始化角色服务
        /// </summary>
        /// <param name="roleManager">Identity角色服务</param>
        /// <param name="roleRepository">角色仓储</param>
        public RoleManager(RoleManager<Role> roleManager, IRoleRepository roleRepository)
        {
            Manager = roleManager;
            RoleRepository = roleRepository;
        }

        /// <summary>
        /// Identity角色服务
        /// </summary>
        private RoleManager<Role> Manager { get; }
        /// <summary>
        /// 角色仓储
        /// </summary>
        private IRoleRepository RoleRepository { get; }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="role">角色</param>
        public virtual async Task CreateAsync(Role role)
        {
            await ValidateCreate(role);
            role.Init();
            var parent = await RoleRepository.FindAsync(role.ParentId);
            role.InitPath(parent);
            role.SortId = await RoleRepository.GenerateSortIdAsync(role.ParentId);
            var result = await Manager.CreateAsync(role);
            result.ThrowIfError();
        }

        /// <summary>
        /// 创建角色验证
        /// </summary>
        /// <param name="role">角色</param>
        protected virtual async Task ValidateCreate(Role role)
        {
            role.CheckNull(nameof(role));
            if (await RoleRepository.ExistsAsync(t => t.Code == role.Code))
                ThrowDuplicateCodeException(role.Code);
        }

        /// <summary>
        /// 抛出编码重复异常
        /// </summary>
        protected void ThrowDuplicateCodeException(string code)
        {
            throw new Warning(string.Format(DefaultResource.DuplicateRoleCode, code));
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        public async Task UpdateAsync(Role role)
        {
            role.CheckNull(nameof(role));
            await ValidateUpdate(role);
            role.InitPinYin();
            await RoleRepository.UpdatePathAsync(role);
            var result = await Manager.UpdateAsync(role);
            result.ThrowIfError();
        }

        /// <summary>
        /// 修改角色验证
        /// </summary>
        /// <param name="role">角色</param>
        protected async Task ValidateUpdate(Role role)
        {
            if (await RoleRepository.ExistsAsync(t => t.Id != role.Id && t.Code == role.Code))
                ThrowDuplicateCodeException(role.Code);
        }

        /// <summary>
        /// 添加用户到角色
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <param name="userIds">用户标识列表</param>
        public async Task AddUsersToRoleAsync(Guid roleId, List<Guid> userIds)
        {
            if (roleId.IsEmpty() || userIds == null)
                return;
            var existsUserIds = await RoleRepository.GetExistsUserIdsAsync(roleId, userIds);
            userIds = userIds.ToList().Except(existsUserIds).ToList();
            var userRoles = CreateUserRoles(roleId, userIds);
            await RoleRepository.AddUserRolesAsync(userRoles);
        }

        /// <summary>
        /// 创建用户角色列表
        /// </summary>
        private List<UserRole> CreateUserRoles(Guid roleId, List<Guid> userIds)
        {
            return userIds.Where(id => id.IsEmpty() == false).Select(userId => new UserRole(userId, roleId)).ToList();
        }

        /// <summary>
        /// 从角色移除用户
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <param name="userIds">用户标识列表</param>
        public Task RemoveUsersFromRoleAsync(Guid roleId, List<Guid> userIds)
        {
            if (roleId.IsEmpty() || userIds == null)
                return Task.CompletedTask;
            var userRoles = CreateUserRoles(roleId, userIds);
            RoleRepository.RemoveUserRoles(userRoles);
            return Task.CompletedTask;
        }
    }
}
