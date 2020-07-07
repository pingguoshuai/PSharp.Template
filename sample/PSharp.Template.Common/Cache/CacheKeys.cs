using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using PSharp.Template.Core.Caches;

namespace PSharp.Template.Common.Cache
{
    public class CacheKeys : ICacheKey
    {
        [Description("字典信息")]
        public static string DicInfoListByCode = "Common:DicInfo:ListByCode:";
    }
}
