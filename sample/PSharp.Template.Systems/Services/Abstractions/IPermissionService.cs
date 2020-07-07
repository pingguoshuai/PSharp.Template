using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PSharp.Template.Systems.Domains.Models;
using Util.Applications;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Dtos.Requests;
using PSharp.Template.Systems.Services.Queries;
using Util.Aspects;
using Util.Validations.Aspects;

namespace PSharp.Template.Systems.Services.Abstractions {
    /// <summary>
    /// 服务
    /// </summary>
    public interface IPermissionService : IService
    {
        /// <summary>
        /// 获取资源标识列表
        /// </summary>
        /// <param name="query">权限参数</param>
        Task<List<Guid>> GetResourceIdsAsync(PermissionQuery query);

        /// <summary>
        /// 获取接口code列表
        /// </summary>
        /// <param name="query">权限参数</param>
        Task<List<string>> GetInterfaceCodesAsync(PermissionQuery query);

        /// <summary>
        /// 保存接口权限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task SaveInterfaceAsync(CreateRoleInterfaceRequest request);

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task SaveAsync([NotNull][Valid] CreatePermissionRequest request);

        /// <summary>
        /// 获取所有页面资源权限
        /// </summary>
        /// <returns></returns>
        Task<List<PermissionDto>> GetAllAsync();

        /// <summary>
        /// 获取所有接口权限
        /// </summary>
        /// <returns></returns>
        List<RoleInterface> GetAllRoleInterface();
    }
}