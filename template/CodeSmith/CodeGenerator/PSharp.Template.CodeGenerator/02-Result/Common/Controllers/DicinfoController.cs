using Util.Webs.Controllers;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Queries;
using PSharp.Template.Common.Services.Abstractions;
using PSharp.Template.Common.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Common.Controllers {
    /// <summary>
    /// 数据字典控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Common")]
    public class DicinfoController : CrudControllerBase<DicinfoDto, CreateDicinfoRequest, UpdateDicinfoRequest, DicinfoQuery> {
        /// <summary>
        /// 初始化数据字典控制器
        /// </summary>
        /// <param name="service">数据字典服务</param>
        public DicinfoController( IDicinfoService service ) : base( service ) {
            DicinfoService = service;
        }
        
        /// <summary>
        /// 数据字典服务
        /// </summary>
        public IDicinfoService DicinfoService { get; }
    }
}