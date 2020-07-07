using Util.Webs.Controllers;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Queries;
using PSharp.Template.Common.Services.Abstractions;
using PSharp.Template.Common.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Common.Controllers {
    /// <summary>
    /// 字典类型控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Common")]
    public class DictypeController : CrudControllerBase<DictypeDto, CreateDictypeRequest, UpdateDictypeRequest, DictypeQuery> {
        /// <summary>
        /// 初始化字典类型控制器
        /// </summary>
        /// <param name="service">字典类型服务</param>
        public DictypeController( IDictypeService service ) : base( service ) {
            DictypeService = service;
        }
        
        /// <summary>
        /// 字典类型服务
        /// </summary>
        public IDictypeService DictypeService { get; }
    }
}