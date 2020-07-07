using System.ComponentModel;
using PSharp.Template.Core.Attributes;
using PSharp.Template.Systems.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Util.Webs.Controllers;

namespace PSharp.Template.Systems.Controllers
{
    /// <summary>
    /// 缓存管理
    /// </summary>
    [ApiExplorerSettings(GroupName = "Systems")]
    [Description("缓存管理")]
    [AllowLoggedIn]
    public class CacheController : WebApiControllerBase
    {
        private readonly ICacheService _cacheService;

        public CacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Description("查询")]
        public IActionResult Query()
        {
            return Success(_cacheService.GetAll());
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpPost("Remove")]
        [Description("移除")]
        public IActionResult Remove(string key)
        {
            _cacheService.Remove(key);
            return Success();
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <returns></returns>
        [HttpPost("Clear")]
        [Description("清空")]
        public IActionResult Clear()
        {
            _cacheService.Clear();
            return Success();
        }
    }
}
