using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PSharp.Template.Systems.Domains.Enums
{
    public enum ApplicationType
    {
        /// <summary>
        /// 常规应用
        /// </summary>
        [Description("常规应用")]
        General = 1,
        /// <summary>
        /// Api
        /// </summary>
        [Description("Api")]
        Api = 2,
        /// <summary>
        /// 客户端
        /// </summary>
        [Description("客户端")]
        Client = 3
    }
}
