using Util.Webs.Controllers;
using PSharp.Template.Business.Services.Dtos;
using PSharp.Template.Business.Services.Queries;
using PSharp.Template.Business.Services.Abstractions;
using PSharp.Template.Business.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Business.Controllers {
    /// <summary>
    /// 栏目控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Business")]
    public class ColumnController : CrudControllerBase<ColumnDto, CreateColumnRequest, UpdateColumnRequest, ColumnQuery> {
        /// <summary>
        /// 初始化栏目控制器
        /// </summary>
        /// <param name="service">栏目服务</param>
        public ColumnController( IColumnService service ) : base( service ) {
            ColumnService = service;
        }
        
        /// <summary>
        /// 栏目服务
        /// </summary>
        public IColumnService ColumnService { get; }
    }
}