using Util.Webs.Controllers;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Systems.Controllers {
    /// <summary>
    /// 管理员控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Systems")]
    public class UserController : CrudControllerBase<UserDto, CreateUserRequest, UpdateUserRequest, UserQuery> {
        /// <summary>
        /// 初始化管理员控制器
        /// </summary>
        /// <param name="service">管理员服务</param>
        public UserController( IUserService service ) : base( service ) {
            UserService = service;
        }
        
        /// <summary>
        /// 管理员服务
        /// </summary>
        public IUserService UserService { get; }
    }
}