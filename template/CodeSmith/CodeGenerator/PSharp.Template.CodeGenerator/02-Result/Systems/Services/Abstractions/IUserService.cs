using Util.Applications;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Dtos.Requests;
using PSharp.Template.Systems.Services.Queries;

namespace PSharp.Template.Systems.Services.Abstractions {
    /// <summary>
    /// 管理员服务
    /// </summary>
    public interface IUserService : ICrudService<UserDto, UpdateUserRequest, CreateUserRequest, UpdateUserRequest, UserQuery> {
    }
}