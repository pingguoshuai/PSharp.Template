using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PSharp.Template.Systems.Domains.Enums
{
    public enum ResourceType
    {
        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        Menu = 1,
        /// <summary>
        /// 操作
        /// </summary>
        [Description("操作")]
        Operation = 2,
        ///// <summary>
        ///// 模块
        ///// </summary>
        //[Description("模块")]
        //Module = 3,
        ///// <summary>
        ///// 列
        ///// </summary>
        //[Description("列")]
        //Column = 4,
        ///// <summary>
        ///// 行集
        ///// </summary>
        //[Description("行集")]
        //Rows = 5,
        ///// <summary>
        ///// 身份资源
        ///// </summary>
        //[Description("身份资源")]
        //Identity = 6,
        ///// <summary>
        ///// Api资源
        ///// </summary>
        //[Description("Api资源")]
        //Api = 7
    }
}
