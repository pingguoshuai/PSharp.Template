using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PSharp.Template.Core.Attributes;
using PSharp.Template.Core.Helper;
using PSharp.Template.Core.Options;
using PSharp.Template.Core.Results;
using PSharp.Template.Systems.Domains.Models;
using Util.Webs.Controllers;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Extensions;
using PSharp.Template.Systems.Services.Dtos.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Util;
using Util.Security;
using Util.Webs.Properties;

namespace PSharp.Template.Systems.Controllers {
    /// <summary>
    /// 控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Systems")]
    [Description("用户管理")]
    public class UserController : CrudControllerBase<UserDto, CreateUserRequest, UpdateUserRequest, UserQuery> {
        private readonly IResourceService _resourceService;
        private readonly IRoleService _roleService;

        /// <summary>
        /// 初始化控制器
        /// </summary>
        /// <param name="service">服务</param>
        /// <param name="resourceService"></param>
        /// <param name="roleService"></param>
        public UserController(IUserService service,
            IResourceService resourceService,
            IRoleService roleService) : base(service)
        {
            _resourceService = resourceService;
            _roleService = roleService;
            UserService = service;
        }
        
        /// <summary>
        /// 服务
        /// </summary>
        private IUserService UserService { get; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginRequest">登录参数</param>
        /// <returns></returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        [Description("登录")]
        public async Task<IActionResult> Login([FromBody]LoginRequest loginRequest)
        {
            var result = await UserService.SignInAsync(loginRequest);
            if (result.State == SignInState.Failed)
            {
                return Fail(result.Message);
            }
            //var claimIdentity = new ClaimsIdentity("Cookie");
            //claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1"));
            //claimIdentity.AddClaim(new Claim(ClaimTypes.Name, "2"));
            //claimIdentity.AddClaim(new Claim(ClaimTypes.Email, "3"));
            //claimIdentity.AddClaim(new Claim(ClaimTypes.MobilePhone, "4"));
            //claimIdentity.AddClaim(new Claim(ClaimTypes.DateOfBirth, "5"));

            //var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
            //await HttpContext.SignInAsync(claimsPrincipal);

            return Success(result.Data);
        }

        /// <summary>
        /// 获取用户的角色标识列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRolesIds")]
        [Description("获取用户的角色标识列表")]
        public async Task<IActionResult> GetRolesIdsAsync(string userId)
        {
            if (userId.IsEmpty())
                return Fail(WebResource.QueryIsEmpty);
            return Success(await _roleService.GetRolesIdsAsync(userId.ToGuid()));
        }

        /// <summary>
        /// 用户指定角色
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AddRolesToUser")]
        [Description("用户指定角色")]
        public async Task<IActionResult> AddRolesToUserAsync([FromBody] RoleUserRequest request)
        {
            await UserService.AddUsersToRoleAsync(request);
            return Success();
        }

        /// <summary>
        /// 获取登录菜单等信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("Info")]
        [Description("获取登录菜单等信息")]
        [AllowLoggedIn]
        public async Task<IActionResult> GetInfo()
        {
            var appId = Session.GetApplicationId();
            var data = new
            {
                Menus = await _resourceService.GetMenuAsync(),
                Roles = (await _roleService.GetRolesAsync(Session.UserId.ToGuid())).Select(t => t.Code),
                Info = await UserService.GetByIdAsync(Session.UserId.ToGuid())
            };
            return Success(data);
        }

        [AllowLoggedIn]
        public override Task<IActionResult> GetAsync(string id)
        {
            return base.GetAsync(id);
        }
    }
}