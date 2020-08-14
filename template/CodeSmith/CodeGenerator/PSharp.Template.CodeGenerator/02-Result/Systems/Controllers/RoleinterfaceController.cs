using Util.Webs.Controllers;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Systems.Controllers {
    /// <summary>
    /// 角色接口控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Systems")]
    public class RoleinterfaceController : CrudControllerBase<RoleinterfaceDto, CreateRoleinterfaceRequest, UpdateRoleinterfaceRequest, RoleinterfaceQuery> {
        /// <summary>
        /// 初始化角色接口控制器
        /// </summary>
        /// <param name="service">角色接口服务</param>
        public RoleinterfaceController( IRoleinterfaceService service ) : base( service ) {
            RoleinterfaceService = service;
        }
        
        /// <summary>
        /// 角色接口服务
        /// </summary>
        public IRoleinterfaceService RoleinterfaceService { get; }
    }
}