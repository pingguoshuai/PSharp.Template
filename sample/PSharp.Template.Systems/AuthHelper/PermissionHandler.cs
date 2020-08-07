using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PSharp.Template.Core.Attributes;
using PSharp.Template.Systems.Services.Abstractions;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Util;
using Util.Helpers;
using Util.Security;

namespace PSharp.Template.Systems.AuthHelper
{
    public class PermissionRequirement : IAuthorizationRequirement
    {

    }

    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IPermissionService _permissionService;

        public PermissionHandler(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            var session = Util.Sessions.Session.Instance;

            var result = string.IsNullOrWhiteSpace(Web.Identity.GetValue(JwtClaimTypes.Role)) ? Web.Identity.GetValue(ClaimTypes.Role) : Web.Identity.GetValue(JwtClaimTypes.Role);
            var roleIds = result.ToGuidList();
            var applicationId = session.GetApplicationId();

            var roleCodes = session.GetRoleName();
            var userName = session.GetUserName();

            #region 管理员通过

            if (string.Compare(userName, "admin", StringComparison.OrdinalIgnoreCase) == 0 || roleCodes.Contains("admin"))
            {
                context.Succeed(requirement);
                return;
            }

            #endregion

            var resource = context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext;
            if (resource?.ActionDescriptor == null)
            {
                context.Fail();
                return;
            }

            var actionDescriptor = resource.ActionDescriptor as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;
            if (actionDescriptor == null)
            {
                context.Fail();
                return;
            }

            #region 已登录用户都可访问（AllowLoggedInAttribute）

            //controller判断
            var controllerAttributes = actionDescriptor.ControllerTypeInfo.GetCustomAttributesData();
            var loggedIn = controllerAttributes.FirstOrDefault(t => t.AttributeType == typeof(AllowLoggedInAttribute));
            if (loggedIn != null)
            {
                context.Succeed(requirement);
                return;
            }

            //action判断
            var methodAttributes = actionDescriptor.MethodInfo.GetCustomAttributesData();
            loggedIn = methodAttributes.FirstOrDefault(t => t.AttributeType == typeof(AllowLoggedInAttribute));
            if (loggedIn != null)
            {
                context.Succeed(requirement);
                return;
            }

            #endregion

            var controller = actionDescriptor.ControllerName;
            var action = actionDescriptor.ActionName;
            var httpMethod = resource.HttpContext.Request.Method;

            var roleInterfaces = await Task.Run(()=> _permissionService.GetAllRoleInterface());
            roleInterfaces = roleInterfaces.Where(t => t.InterfaceDto != null).ToList();

            var roleInterface = roleInterfaces.FirstOrDefault(t =>
                roleIds.Contains(t.RoleId)
                && t.ApplicationId.Equals(applicationId)
                && t.InterfaceDto.Contorller.Equals(controller, StringComparison.OrdinalIgnoreCase)
                && t.InterfaceDto.Action.Equals(action, StringComparison.OrdinalIgnoreCase)
                && t.InterfaceDto.HttpMethod.Equals(httpMethod, StringComparison.OrdinalIgnoreCase));

            if (roleInterface == null)
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }
    }
}
