using System.ComponentModel;
using Util.Webs.Controllers;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Queries;
using PSharp.Template.Common.Services.Abstractions;
using PSharp.Template.Common.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Common.Controllers {
    /// <summary>
    /// 控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Common")]
    [Description("字典类型管理")]
    public class DicTypeController : CrudControllerBase<DicTypeDto, CreateDicTypeRequest, DicTypeQuery> {
        /// <summary>
        /// 初始化控制器
        /// </summary>
        /// <param name="service">服务</param>
        public DicTypeController( IDicTypeService service ) : base( service ) {
            DicTypeService = service;
        }
        
        /// <summary>
        /// 服务
        /// </summary>
        public IDicTypeService DicTypeService { get; }
    }
}