using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using PSharp.Template.Core.Caches;

namespace PSharp.Template.Systems.Cache
{
    public class CacheKeys : ICacheKey
    {
        [Description("所有页面资源权限列表")]
        public static string PermissionList = "System:Permission:AllList";
        [Description("所有接口权限列表")]
        public static string RoleInterfaceList = "System:RoleInterface:AllList";
    }
}
