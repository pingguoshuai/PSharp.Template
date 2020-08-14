using Util.Applications;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Dtos.Requests;
using PSharp.Template.Common.Services.Queries;

namespace PSharp.Template.Common.Services.Abstractions {
    /// <summary>
    /// 字典类型服务
    /// </summary>
    public interface IDictypeService : ICrudService<DictypeDto, UpdateDictypeRequest, CreateDictypeRequest, UpdateDictypeRequest, DictypeQuery> {
    }
}