using System.ComponentModel;
using System.Threading.Tasks;
using Util.Webs.Controllers;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Systems.Controllers {
    /// <summary>
    /// 控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Systems")]
    [Description("应用程序管理")]
    public class ApplicationController : CrudControllerBase<ApplicationDto, CreateApplicationRequest, ApplicationQuery> {
        /// <summary>
        /// 初始化控制器
        /// </summary>
        /// <param name="service">服务</param>
        public ApplicationController( IApplicationService service ) : base( service ) {
            ApplicationService = service;
        }
        
        /// <summary>
        /// 服务
        /// </summary>
        public IApplicationService ApplicationService { get; }

        /// <summary>
        /// 获取全部应用程序
        /// </summary>
        [HttpGet("all")]
        [Description("获取全部应用程序")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await ApplicationService.GetAllAsync();
            return Success(result);
        }
    }
}