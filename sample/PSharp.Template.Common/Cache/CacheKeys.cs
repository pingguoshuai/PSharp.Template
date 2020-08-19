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
        public const string DicInfoListByCode = "Common:DicInfo:ListByCode:";
        [Description("地区信息")]
        public const string AreaListByParent = "Common:Area:ListByParent:";
    }
}
