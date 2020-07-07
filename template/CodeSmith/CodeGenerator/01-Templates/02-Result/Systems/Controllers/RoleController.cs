using Util.Ui.Controllers;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Systems.Controllers {
    /// <summary>
    /// 角色控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Systems")]
    public class RoleController : TreeControllerBase<RoleDto, RoleQuery> {
        /// <summary>
        /// 初始化角色控制器
        /// </summary>
        /// <param name="service">角色服务</param>
        public RoleController( IRoleService service ) : base( service ) {
            RoleService = service;
        }

        /// <summary>
        /// 角色服务
        /// </summary>
        public IRoleService RoleService { get; }
    }
}