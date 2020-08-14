using Util.Applications;
using PSharp.Template.Business.Services.Dtos;
using PSharp.Template.Business.Services.Dtos.Requests;
using PSharp.Template.Business.Services.Queries;

namespace PSharp.Template.Business.Services.Abstractions {
    /// <summary>
    /// 栏目服务
    /// </summary>
    public interface IColumnService : ICrudService<ColumnDto, UpdateColumnRequest, CreateColumnRequest, UpdateColumnRequest, ColumnQuery> {
    }
}