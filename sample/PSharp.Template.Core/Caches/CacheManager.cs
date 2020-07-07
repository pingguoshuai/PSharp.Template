using System;
using System.Collections.Generic;
using System.Text;
using EasyCaching.Core;

namespace PSharp.Template.Core.Caches
{
    public class CacheManager : Util.Caches.EasyCaching.CacheManager, ICache
    {
        private readonly IEasyCachingProvider _provider;

        public CacheManager(IEasyCachingProvider provider) : base(provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// 根据前缀删除缓存
        /// </summary>
        /// <param name="prefix"></param>
        public void RemovePrefix(string prefix)
        {
            _provider.RemoveByPrefix(prefix);
        }
    }
}
