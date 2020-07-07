using Util.Webs.Controllers;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Systems.Controllers {
    /// <summary>
    /// 权限控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Systems")]
    public class PermissionController : CrudControllerBase<PermissionDto, CreatePermissionRequest, UpdatePermissionRequest, PermissionQuery> {
        /// <summary>
        /// 初始化权限控制器
        /// </summary>
        /// <param name="service">权限服务</param>
        public PermissionController( IPermissionService service ) : base( service ) {
            PermissionService = service;
        }
        
        /// <summary>
        /// 权限服务
        /// </summary>
        public IPermissionService PermissionService { get; }
    }
}