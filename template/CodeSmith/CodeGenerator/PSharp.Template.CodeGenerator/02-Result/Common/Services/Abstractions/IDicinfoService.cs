using Util.Applications;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Dtos.Requests;
using PSharp.Template.Common.Services.Queries;

namespace PSharp.Template.Common.Services.Abstractions {
    /// <summary>
    /// 数据字典服务
    /// </summary>
    public interface IDicinfoService : ICrudService<DicinfoDto, UpdateDicinfoRequest, CreateDicinfoRequest, UpdateDicinfoRequest, DicinfoQuery> {
    }
}