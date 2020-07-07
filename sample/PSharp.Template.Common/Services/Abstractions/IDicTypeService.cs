using Util.Applications;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Dtos.Requests;
using PSharp.Template.Common.Services.Queries;

namespace PSharp.Template.Common.Services.Abstractions {
    /// <summary>
    /// 服务
    /// </summary>
    public interface IDicTypeService : ICrudService<DicTypeDto, CreateDicTypeRequest, DicTypeQuery> {
    }
}