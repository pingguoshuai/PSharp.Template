using Util.Ui.Controllers;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Systems.Controllers {
    /// <summary>
    /// 身份资源控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Systems")]
    public class ResourceController : TreeControllerBase<ResourceDto, ResourceQuery> {
        /// <summary>
        /// 初始化身份资源控制器
        /// </summary>
        /// <param name="service">身份资源服务</param>
        public ResourceController( IResourceService service ) : base( service ) {
            ResourceService = service;
        }

        /// <summary>
        /// 身份资源服务
        /// </summary>
        public IResourceService ResourceService { get; }
    }
}