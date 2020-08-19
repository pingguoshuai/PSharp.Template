using System;
using System.ComponentModel;
using Util.Ui.Controllers;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Queries;
using PSharp.Template.Common.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PSharp.Template.Common.Services.Dtos.Requests;
using Util;
using Util.Applications.Trees;
using Util.Exceptions;

namespace PSharp.Template.Common.Controllers {
    /// <summary>
    /// 行政区划
    /// </summary>
    [ApiExplorerSettings(GroupName = "Common")]
    [Description("行政区划管理")]
    public class AreaController : TreeControllerBase<AreaDto, AreaQuery, int?>
    {
        /// <summary>
        /// 初始化行政区划控制器
        /// </summary>
        /// <param name="service">行政区划服务</param>
        public AreaController(IAreaService service) : base(service)
        {
            AreaService = service;
        }

        /// <summary>
        /// 行政区划服务
        /// </summary>
        public IAreaService AreaService { get; }

        protected override LoadMode GetLoadMode()
        {
            return LoadMode.Async;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override async Task<IActionResult> QueryAsync(AreaQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            if (query.Order.IsEmpty())
                query.Order = "SortId";
            query.Path = null;
            switch (query.Operation)
            {
                case LoadOperation.FirstLoad:
                    query.Level = 1;
                    query.ParentId = default(int);
                    break;
                case LoadOperation.LoadChild:
                    query.Level = null;
                    query.Path = null;
                    break;
                default:
                    throw new Warning("非法请求");
            }

            return Success( await AreaService.QueryAsync(query));
        }

        /// <summary>
        /// 根据父id查询列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [HttpGet("GetListByPid")]
        [AllowAnonymous]
        public async Task<IActionResult> GetListByPid(int parentId)
        {
            return Success(await AreaService.GetListByPid(parentId));
        }

        /// <summary>
        /// 创建地区
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("创建")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAreaRequest request)
        {
            return Success(await AreaService.CreateAsync(request));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Description("修改")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAreaRequest request)
        {
            await AreaService.UpdateAsync(request);
            return Success();
        }
    }
}