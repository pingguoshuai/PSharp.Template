using System.ComponentModel;
using Util.Webs.Controllers;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Queries;
using PSharp.Template.Common.Services.Abstractions;
using PSharp.Template.Common.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace PSharp.Template.Common.Controllers {
    /// <summary>
    /// 控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Common")]
    [Description("字典管理")]
    public class DicInfoController : CrudControllerBase<DicInfoDto, CreateDicInfoRequest, DicInfoQuery> {
        /// <summary>
        /// 初始化控制器
        /// </summary>
        /// <param name="service">服务</param>
        public DicInfoController( IDicInfoService service ) : base( service ) {
            DicInfoService = service;
        }
        
        /// <summary>
        /// 服务
        /// </summary>
        public IDicInfoService DicInfoService { get; }

        /// <summary>
        /// 根据父code 查询列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("GetListByTypeCode")]
        [Description("根据父code 查询列表")]
        [AllowAnonymous]
        public async Task<IActionResult> GetListByTypeCode(string code)
        {
            return Success( await DicInfoService.GetListByTypeCode(code));
        }

        /// <summary>
        /// 根据value 和 父code查询实体
        /// </summary>
        /// <param name="typecode"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet("GetByCodeAndValue")]
        [Description("根据value 和 父code查询实体")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByCodeAndValue(string typecode, string value)
        {
            return Success(await DicInfoService.GetByCodeAndValue(typecode, value));
        }
    }
}