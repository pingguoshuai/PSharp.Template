using Util.Webs.Controllers;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Queries;
using PSharp.Template.Common.Services.Abstractions;
using PSharp.Template.Common.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Common.Controllers {
    /// <summary>
    /// 文件控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Common")]
    public class SysfileController : CrudControllerBase<SysfileDto, CreateSysfileRequest, UpdateSysfileRequest, SysfileQuery> {
        /// <summary>
        /// 初始化文件控制器
        /// </summary>
        /// <param name="service">文件服务</param>
        public SysfileController( ISysfileService service ) : base( service ) {
            SysfileService = service;
        }
        
        /// <summary>
        /// 文件服务
        /// </summary>
        public ISysfileService SysfileService { get; }
    }
}