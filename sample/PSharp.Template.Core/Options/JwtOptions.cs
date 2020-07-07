using System;
using System.Collections.Generic;
using System.Text;

namespace PSharp.Template.Core.Options
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = "pgs";
        public string Audience { get; set; } = "pgs";

        /// <summary>
        /// 加密key
        /// </summary>
        public string SecretKey { get; set; } = "BB3647441FFA4B5DB4E64A29B53CE525";
        /// <summary>
        /// 生命周期
        /// </summary>
        public int Lifetime { get; set; } = 20;
        /// <summary>
        /// 是否验证生命周期
        /// </summary>
        public bool ValidateLifetime { get; set; } = true;

        /// <summary>
        /// 验证头字段
        /// </summary>
        public string HeadField { get; set; } = "useless";

        /// <summary>
        /// jwt验证前缀
        /// </summary>
        public string Prefix { get; set; } = "Bearer";

        /// <summary>
        /// 忽略验证的url
        /// </summary>
        public List<string> IgnoreUrls { get; set; }
    }
}
