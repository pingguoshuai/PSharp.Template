using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSharp.Template.Core.Caches;
using PSharp.Template.Systems.AuthHelper;
using PSharp.Template.Systems.Cache;
using Util;
using Util.Maps;
using Util.Applications;
using PSharp.Template.UnitOfWork;
using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Requests;
using Microsoft.EntityFrameworkCore;

namespace PSharp.Template.Systems.Services.Implements {
    /// <summary>
    /// 服务
    /// </summary>
    public class PermissionService : ServiceBase, IPermissionService {
        private readonly IDefaultUnitOfWork _unitOfWork;
        private readonly ICache _cache;

        /// <summary>
        /// 初始化服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="permissionRepository">仓储</param>
        /// <param name="cache"></param>
        public PermissionService(IDefaultUnitOfWork unitOfWork, IPermissionRepository permissionRepository, ICache cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            PermissionRepository = permissionRepository;
        }

        /// <summary>
        /// 仓储
        /// </summary>
        public IPermissionRepository PermissionRepository { get; set; }

        /// <summary>
        /// 获取资源标识列表
        /// </summary>
        /// <param name="query">权限参数</param>
        public async Task<List<Guid>> GetResourceIdsAsync(PermissionQuery query)
        {
            return await PermissionRepository.GetResourceIdsAsync(query.ApplicationId.SafeValue(), query.RoleId.SafeValue(), query.IsDeny.SafeValue());
        }

        /// <summary>
        /// 获取接口code列表
        /// </summary>
        /// <param name="query">权限参数</param>
        public async Task<List<string>> GetInterfaceCodesAsync(PermissionQuery query)
        {
            return await PermissionRepository.GetInterfaceCodesAsync(query.ApplicationId.SafeValue(), query.RoleId.SafeValue());
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task SaveAsync(CreatePermissionRequest request)
        {
            await PermissionRepository.SaveAsync(request.ApplicationId.SafeValue(), request.RoleId, request.ResourceIds.ToGuidList(),
                request.IsDeny.SafeValue());
            await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// 保存接口权限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task SaveInterfaceAsync(CreateRoleInterfaceRequest request)
        {
            await PermissionRepository.SaveInterfaceAsync(request.ApplicationId.SafeValue(), request.RoleId,
                Util.Helpers.Convert.ToList<string>(request.InterfaceCodes));

            await _unitOfWork.CommitAsync();
        }

        protected PermissionDto ToDto(Permission permission)
        {
            return permission.MapTo<PermissionDto>();
        }

        /// <summary>
        /// 获取所有页面资源权限
        /// </summary>
        /// <returns></returns>
        public async Task<List<PermissionDto>> GetAllAsync()
        {
            if (!_cache.Exists(CacheKeys.PermissionList))
            {
                var entities = await PermissionRepository.Find()
                    .Include(t => t.Resource)
                    .ToListAsync();
                var list = entities.Select(ToDto).ToList();

                if (list.Count > 0) _cache.TryAdd(CacheKeys.PermissionList, list);
                return list;
            }

            return _cache.Get<List<PermissionDto>>(CacheKeys.PermissionList, () => null);
        }

        /// <summary>
        /// 获取所有接口权限
        /// </summary>
        /// <returns></returns>
        public List<RoleInterface> GetAllRoleInterface()
        {
            if (!_cache.Exists(CacheKeys.RoleInterfaceList))
            {
                var list = PermissionRepository.GetAllRoleInterface();
                if (list.Count > 0) _cache.TryAdd(CacheKeys.RoleInterfaceList, list);
                return list;
            }
            return _cache.Get<List<RoleInterface>>(CacheKeys.RoleInterfaceList, () => null);
        }
    }
}