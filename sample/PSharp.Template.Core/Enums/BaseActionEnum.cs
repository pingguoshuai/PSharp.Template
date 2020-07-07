using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PSharp.Template.Core.Enums
{
    public enum BaseActionEnum
    {
        [Description("创建")]
        CreateAsync,
        [Description("修改")]
        UpdateAsync,
        [Description("删除")]
        DeleteAsync,
        [Description("批量删除")]
        BatchDeleteAsync,
        [Description("批量保存")]
        SaveAsync,
        [Description("获取单个实例")]
        GetAsync,
        [Description("分页查询")]
        PagerQueryAsync,
        [Description("查询")]
        QueryAsync,
        [Description("获取项列表")]
        GetItemsAsync
    }
}
