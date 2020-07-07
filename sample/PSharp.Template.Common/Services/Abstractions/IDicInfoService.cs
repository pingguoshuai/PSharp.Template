using System.Collections.Generic;
using Util.Applications;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Dtos.Requests;
using PSharp.Template.Common.Services.Queries;
using System.Threading.Tasks;

namespace PSharp.Template.Common.Services.Abstractions {
    /// <summary>
    /// 服务
    /// </summary>
    public interface IDicInfoService : ICrudService<DicInfoDto, CreateDicInfoRequest, DicInfoQuery>
    {
        Task<DicInfoDto> GetByCodeAndValue(string typecode, string value);
        Task<List<DicInfoDto>> GetListByTypeCode(string typeCode);
    }
}