using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using PSharp.Template.Systems.Domains.Enums;
using Util.Ui.Controllers;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;
using Util.Ui.Data;
using Util.Webs.Controllers;
using Enum = Util.Helpers.Enum;

namespace PSharp.Template.Systems.Controllers {
    /// <summary>
    /// 控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Systems")]
    [Description("资源管理")]
    public class ResourceController : TreeControllerBase<ResourceDto, ResourceQuery> {
        /// <summary>
        /// 初始化控制器
        /// </summary>
        /// <param name="service">服务</param>
        public ResourceController( IResourceService service ) : base( service ) {
            ResourceService = service;
        }

        /// <summary>
        /// 服务
        /// </summary>
        public IResourceService ResourceService { get; }

        /// <summary>
        /// 查询树形
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public override async Task<IActionResult> QueryAsync(ResourceQuery query)
        {
            var data = await ResourceService.QueryAsync(query);
            
            return Success(new Core.Results.TreeResult<ResourceDto>(data).GetResult());
        }

        /// <summary>
        /// 创建模块
        /// </summary>
        /// <param name="request">创建参数</param>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateResourceRequest request)
        {
            var id = await ResourceService.CreateAsync(request);
            return Success(id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Description("修改")]
        public async Task<IActionResult> UpdateAsync([FromBody] ResourceDto request)
        {
            await ResourceService.UpdateAsync(request);
            return Success();
        }

        /// <summary>
        /// 获取资源类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetResourceType")]
        public IActionResult GetResourceType()
        {
            return Success(Enum.GetItems(typeof(ResourceType)));
        }
    }
}