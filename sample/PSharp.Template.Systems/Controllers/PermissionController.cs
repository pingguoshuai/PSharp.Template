using System.ComponentModel;
using System.Threading.Tasks;
using Util.Webs.Controllers;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Systems.Controllers {
    /// <summary>
    /// 控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Systems")]
    [Description("权限管理")]
    public class PermissionController : WebApiControllerBase {
        /// <summary>
        /// 初始化控制器
        /// </summary>
        /// <param name="service">服务</param>
        public PermissionController( IPermissionService service ){
            PermissionService = service;
        }
        
        /// <summary>
        /// 服务
        /// </summary>
        public IPermissionService PermissionService { get; }

        /// <summary>
        /// 获取资源标识列表
        /// </summary>
        /// <param name="query">查询参数</param>
        [HttpGet("resourceIds")]
        [Description("获取资源标识列表")]
        public async Task<IActionResult> GetResourceIdsAsync(PermissionQuery query)
        {
            var result = await PermissionService.GetResourceIdsAsync(query);
            return Success(result);
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="request">参数</param>
        [HttpPost]
        [Description("保存资源权限")]
        public async Task<IActionResult> SaveAsync([FromBody] CreatePermissionRequest request)
        {
            await PermissionService.SaveAsync(request);
            return Success();
        }

        /// <summary>
        /// 获取接口code列表
        /// </summary>
        /// <param name="query">查询参数</param>
        [HttpGet("InterfaceCodes")]
        [Description("获取接口code列表")]
        public async Task<IActionResult> GetInterfaceCodesAsync(PermissionQuery query)
        {
            var result = await PermissionService.GetInterfaceCodesAsync(query);
            return Success(result);
        }

        /// <summary>
        /// 保存接口权限
        /// </summary>
        /// <param name="request">参数</param>
        [HttpPost("SaveInterface")]
        [Description("保存接口权限")]
        public async Task<IActionResult> SaveInterfaceAsync([FromBody] CreateRoleInterfaceRequest request)
        {
            await PermissionService.SaveInterfaceAsync(request);
            return Success();
        }
    }
}