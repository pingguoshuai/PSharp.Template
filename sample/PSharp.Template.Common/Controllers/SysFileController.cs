using System.ComponentModel;
using Util.Webs.Controllers;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Queries;
using PSharp.Template.Common.Services.Abstractions;
using PSharp.Template.Common.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using PSharp.Template.Core.Files;

namespace PSharp.Template.Common.Controllers
{
    /// <summary>
    /// 控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Common")]
    [Description("文件管理")]
    public class SysFileController : CrudControllerBase<SysFileDto, CreateSysFileRequest, SysFileQuery>
    {
        private readonly IFileStore _fileStore;

        /// <summary>
        /// 初始化控制器
        /// </summary>
        /// <param name="service">服务</param>
        /// <param name="fileStore"></param>
        public SysFileController(ISysFileService service, IFileStore fileStore) : base(service)
        {
            _fileStore = fileStore;
            SysFileService = service;
        }

        /// <summary>
        /// 服务
        /// </summary>
        public ISysFileService SysFileService { get; }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("Upload")]
        [Description("上传图片")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var stream = file.OpenReadStream();

            return Success(await SysFileService.UploadByStream(stream, file.FileName, _fileStore.IsImage));
        }

        /// <summary>
        /// 上传视频
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("UploadVideo")]
        [Description("上传视频")]
        public async Task<IActionResult> UploadVideo(IFormFile file)
        {
            var stream = file.OpenReadStream();

            return Success(await SysFileService.UploadByStream(stream, file.FileName, _fileStore.IsVideo));
        }
    }
}