using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSharp.Template.Systems.AuthHelper;
using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Util;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Systems.Datas.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository {
        private readonly InterfaceCollection _interfaceCollection;

        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="interfaceCollection"></param>
        public PermissionRepository( IDefaultUnitOfWork unitOfWork ,
            InterfaceCollection interfaceCollection) : base( unitOfWork )
        {
            _interfaceCollection = interfaceCollection;
        }

        /// <summary>
        /// 保存接口权限
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="roleId"></param>
        /// <param name="codes"></param>
        /// <returns></returns>
        public async Task SaveInterfaceAsync(Guid applicationId, Guid roleId, List<string> codes)
        {
            if (codes == null)
                return;
            var oldCodes = await GetInterfaceCodesAsync(applicationId, roleId);
            var result = codes.Compare(oldCodes);

            var addList = result.CreateList.Select(code =>
            {
                var ri =new RoleInterface(roleId, code, applicationId);
                ri.Init();
                return ri;
            });
            await UnitOfWork.Set<RoleInterface>().AddRangeAsync(addList);

            var removeList = UnitOfWork.Set<RoleInterface>().Where(t => result.DeleteList.Contains(t.InterfaceCode));
            UnitOfWork.Set<RoleInterface>().RemoveRange(removeList);
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="roleId"></param>
        /// <param name="resourceIds"></param>
        /// <param name="isDeny"></param>
        /// <returns></returns>
        public async Task SaveAsync( Guid applicationId, Guid roleId, List<Guid> resourceIds, bool isDeny)
        {
            if (resourceIds == null)
                return;
            var oldResourceIds = await GetResourceIdsAsync(applicationId, roleId, isDeny);

            var result = resourceIds.Compare(oldResourceIds);

            await AddAsync(ToPermissions(roleId, result.CreateList, isDeny));
            await RemoveAsync(roleId, result.DeleteList);
        }

        /// <summary>
        /// 转换为权限实体列表
        /// </summary>
        private List<Permission> ToPermissions(Guid roleId, List<Guid> resourceIds, bool isDeny)
        {
            return resourceIds.Select(resourceId => ToPermission(roleId, resourceId, isDeny)).ToList();
        }

        /// <summary>
        /// 转换为权限实体
        /// </summary>
        private Permission ToPermission(Guid roleId, Guid resourceId, bool isDeny)
        {
            var result = new Permission
            {
                RoleId = roleId,
                ResourceId = resourceId,
                IsDeny = isDeny
            };
            result.Init();
            return result;
        }

        /// <summary>
        /// 获取资源标识列表
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="roleId"></param>
        /// <param name="isDeny"></param>
        /// <returns></returns>
        public async Task<List<Guid>> GetResourceIdsAsync(Guid applicationId, Guid roleId, bool isDeny)
        {
            var queryable = from permission in Find()
                            join resource in UnitOfWork.Set<Resource>() on permission.ResourceId equals resource.Id 
                            where resource.ApplicationId == applicationId && permission.RoleId == roleId && permission.IsDeny == isDeny
                            select permission.ResourceId;

            return await queryable.ToListAsync();
        }

        /// <summary>
        /// 获取接口code列表
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<List<string>> GetInterfaceCodesAsync(Guid applicationId, Guid roleId)
        {
            return await Task.Run(() =>
            {
                var queryable = from item in _interfaceCollection.List
                    join role in UnitOfWork.Set<RoleInterface>() on item.Code equals role.InterfaceCode
                    where role.ApplicationId == applicationId && role.RoleId == roleId
                    select item.Code;

                return queryable.ToList();
            });
        }

        /// <summary>
        /// 获取所有接口权限
        /// </summary>
        /// <returns></returns>
        public List<RoleInterface> GetAllRoleInterface()
        {
            var roleInterfaces = from item in _interfaceCollection.List
                join role in UnitOfWork.Set<RoleInterface>() on item.Code equals role.InterfaceCode
                select new RoleInterface(role.RoleId, item.Code, role.ApplicationId)
                {
                    InterfaceDto = item
                };
            return roleInterfaces.ToList();
        }


        /// <summary>
        ///获取权限标识列表
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <param name="resourceIds">资源标识列表</param>
        public async Task<List<Guid>> GetPermissionIdsAsync(Guid roleId, List<Guid> resourceIds)
        {
            return await Find().Where(t => t.RoleId == roleId && resourceIds.Contains(t.ResourceId)).Select(t => t.Id).ToListAsync();
        }

        /// <summary>
        /// 移除权限
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <param name="resourceIds">资源标识列表</param>
        public async Task RemoveAsync(Guid roleId, List<Guid> resourceIds)
        {
            var permissionIds = await GetPermissionIdsAsync(roleId, resourceIds);
            await RemoveAsync(permissionIds);
        }
    }
}