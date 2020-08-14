using Util.Applications;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Dtos.Requests;
using PSharp.Template.Common.Services.Queries;

namespace PSharp.Template.Common.Services.Abstractions {
    /// <summary>
    /// 文件服务
    /// </summary>
    public interface ISysfileService : ICrudService<SysfileDto, UpdateSysfileRequest, CreateSysfileRequest, UpdateSysfileRequest, SysfileQuery> {
    }
}