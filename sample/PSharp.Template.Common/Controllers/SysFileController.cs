using System.ComponentModel;
using Util.Webs.Controllers;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Queries;
using PSharp.Template.Common.Services.Abstractions;
using PSharp.Template.Common.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace PSharp.Template.Common.Controllers
{
    /// <summary>
    /// 控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Common")]
    [Description("文件管理")]
    public class SysFileController : CrudControllerBase<SysFileDto, CreateSysFileRequest, SysFileQuery>
    {
        /// <summary>
        /// 初始化控制器
        /// </summary>
        /// <param name="service">服务</param>
        public SysFileController(ISysFileService service) : base(service)
        {
            SysFileService = service;
        }

        /// <summary>
        /// 服务
        /// </summary>
        public ISysFileService SysFileService { get; }

        [HttpPost("Upload")]
        [Description("上传")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var stream = file.OpenReadStream();

            return Success(await SysFileService.UploadByStream(stream, file.FileName));
        }
    }
}