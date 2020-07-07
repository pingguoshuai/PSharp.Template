using Util.Applications;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Dtos.Requests;
using PSharp.Template.Systems.Services.Queries;

namespace PSharp.Template.Systems.Services.Abstractions {
    /// <summary>
    /// 角色接口服务
    /// </summary>
    public interface IRoleinterfaceService : ICrudService<RoleinterfaceDto, UpdateRoleinterfaceRequest, CreateRoleinterfaceRequest, UpdateRoleinterfaceRequest, RoleinterfaceQuery> {
    }
}