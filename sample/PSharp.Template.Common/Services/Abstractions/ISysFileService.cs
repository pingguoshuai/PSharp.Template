using System.IO;
using System.Threading.Tasks;
using Util.Applications;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Dtos.Requests;
using PSharp.Template.Common.Services.Queries;

namespace PSharp.Template.Common.Services.Abstractions {
    /// <summary>
    /// 服务
    /// </summary>
    public interface ISysFileService : ICrudService<SysFileDto, CreateSysFileRequest, SysFileQuery>
    {
        Task<SysFileDto> GetByMd5Async(string md5);
        Task<SysFileDto> UploadByStream(Stream stream, string oldName);
    }
}