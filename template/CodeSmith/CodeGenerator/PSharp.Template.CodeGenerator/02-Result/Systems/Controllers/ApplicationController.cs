using Util.Webs.Controllers;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Systems.Controllers {
    /// <summary>
    /// 应用程序控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Systems")]
    public class ApplicationController : CrudControllerBase<ApplicationDto, CreateApplicationRequest, UpdateApplicationRequest, ApplicationQuery> {
        /// <summary>
        /// 初始化应用程序控制器
        /// </summary>
        /// <param name="service">应用程序服务</param>
        public ApplicationController( IApplicationService service ) : base( service ) {
            ApplicationService = service;
        }
        
        /// <summary>
        /// 应用程序服务
        /// </summary>
        public IApplicationService ApplicationService { get; }
    }
}