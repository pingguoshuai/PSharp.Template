using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Util.Webs.Controllers;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Util.Reflections;
using Microsoft.AspNetCore.Mvc.Routing;
using Util.Helpers;

namespace PSharp.Template.Systems.Controllers {
    /// <summary>
    /// 接口控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Systems")]
    [Description("接口管理")]
    public class InterfaceController : WebApiControllerBase {
        /// <summary>
        /// 初始化接口控制器
        /// </summary>
        /// <param name="service">接口服务</param>
        public InterfaceController( IInterfaceService service)
        {
            InterfaceService = service;
        }
        
        /// <summary>
        /// 接口服务
        /// </summary>
        public IInterfaceService InterfaceService { get; }

        /// <summary>
        /// 获取全部接口
        /// </summary>
        /// <returns></returns>
        [HttpGet("All")]
        [Description("获取全部接口")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return Success(InterfaceService.GetTree());
        }
    }
}