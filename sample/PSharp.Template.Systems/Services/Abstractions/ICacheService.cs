using System;
using System.Collections.Generic;
using System.Text;
using Util;
using Util.Applications;
using Util.Aspects;

namespace PSharp.Template.Systems.Services.Abstractions
{
    public interface ICacheService : IService
    {
        /// <summary>
        /// 获取全部cache key列表
        /// </summary>
        /// <returns></returns>
        List<Item> GetAll();

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        void Remove([NotEmpty] string key);

        /// <summary>
        /// 清空缓存
        /// </summary>
        void Clear();
    }
}