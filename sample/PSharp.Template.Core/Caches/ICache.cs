using System;
using System.Collections.Generic;
using System.Text;

namespace PSharp.Template.Core.Caches
{
    public interface ICache : Util.Caches.ICache
    {
        /// <summary>
        /// 根据前缀删除缓存
        /// </summary>
        /// <param name="prefix"></param>
        void RemovePrefix(string prefix);
    }
}
