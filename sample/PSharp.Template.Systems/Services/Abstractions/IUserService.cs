using System.Threading.Tasks;
using PSharp.Template.Systems.Domains.Models;
using Util.Applications;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Dtos.Requests;
using PSharp.Template.Systems.Services.Queries;
using Util.Aspects;
using Util.Validations.Aspects;

namespace PSharp.Template.Systems.Services.Abstractions {
    /// <summary>
    /// 服务
    /// </summary>
    public interface IUserService : ICrudService<UserDto, UpdateUserRequest, CreateUserRequest, UpdateUserRequest, UserQuery>
    {
        Task<Core.Results.SignInResult> SignInAsync([NotNull][Valid] LoginRequest request);

        Task<string> GenerateTokenAsync(User user, string purpose, string application = "", string provider = "");

        /// <summary>
        /// 用户指定角色
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task AddUsersToRoleAsync(RoleUserRequest request);
    }
}