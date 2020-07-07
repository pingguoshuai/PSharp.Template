using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications.Trees;
using PSharp.Template.UnitOfWork;
using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.Systems.Domains.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Requests;
using Util.Applications;

namespace PSharp.Template.Systems.Services.Implements {
    /// <summary>
    /// 服务
    /// </summary>
    public class RoleService : DeleteServiceBase<Role, RoleDto, RoleQuery>, IRoleService {
        /// <summary>
        /// 初始化服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="roleRepository">仓储</param>
        public RoleService( IDefaultUnitOfWork unitOfWork, IRoleRepository roleRepository )
            : base( unitOfWork, roleRepository ) {
            RoleRepository = roleRepository;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        public IDefaultUnitOfWork UnitOfWork { get; set; }
        /// <summary>
        /// 角色仓储
        /// </summary>
        public IRoleRepository RoleRepository { get; set; }
        /// <summary>
        /// 角色服务
        /// </summary>
        public IRoleManager RoleManager { get; set; }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Role> CreateQuery(RoleQuery param)
        {
            return new Query<Role>(param)
                .WhereIfNotEmpty(t => t.Code.Contains(param.Code))
                .WhereIfNotEmpty(t => t.Name.Contains(param.Name))
                .WhereIfNotEmpty(t => t.Type.Contains(param.Type))
                .WhereIfNotEmpty(t => t.IsAdmin == param.IsAdmin)
                .WhereIfNotEmpty(t => t.Enabled == param.Enabled);
        }

        /// <summary>
        /// 获取用户的角色列表
        /// </summary>
        /// <param name="userId">用户标识</param>
        public async Task<List<RoleDto>> GetRolesAsync(Guid userId)
        {
            var result = await RoleRepository.GetRolesAsync(userId);
            return result.MapToList<RoleDto>();
        }

        /// <summary>
        /// 获取用户的角色标识列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Guid>> GetRolesIdsAsync(Guid userId)
        {
            var result = await RoleRepository.GetRolesAsync(userId);
            return result.Select(t => t.Id).ToList();
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="request">创建角色参数</param>
        public async Task<Guid> CreateAsync(CreateRoleRequest request)
        {
            var role = request.MapTo<Role>();
            await RoleManager.CreateAsync(role);
            await UnitOfWork.CommitAsync();
            return role.Id;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="request">修改角色参数</param>
        public async Task UpdateAsync(UpdateRoleRequest request)
        {
            var entity = await RoleRepository.FindAsync(request.Id.ToGuid());
            request.MapTo(entity);
            await RoleManager.UpdateAsync(entity);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 添加用户到角色
        /// </summary>
        /// <param name="request">用户角色参数</param>
        public async Task AddUsersToRoleAsync(UserRoleRequest request)
        {
            await RoleManager.AddUsersToRoleAsync(request.RoleId, request.UserIds.ToGuidList());
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 从角色移除用户
        /// </summary>
        /// <param name="request">用户角色参数</param>
        public async Task RemoveUsersFromRoleAsync(UserRoleRequest request)
        {
            await RoleManager.RemoveUsersFromRoleAsync(request.RoleId, request.UserIds.ToGuidList());
            await UnitOfWork.CommitAsync();
        }
    }
}