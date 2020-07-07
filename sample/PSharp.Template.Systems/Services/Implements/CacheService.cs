using System;
using System.Collections.Generic;
using System.Text;
using PSharp.Template.Core.Caches;
using PSharp.Template.Systems.Services.Abstractions;
using Util;
using Util.Applications;

namespace PSharp.Template.Systems.Services.Implements
{
    public class CacheService : ServiceBase, ICacheService
    {
        private readonly CacheKeyManager _cacheKeyManager;
        private readonly ICache _cache;

        public CacheService(CacheKeyManager cacheKeyManager, ICache cache)
        {
            _cacheKeyManager = cacheKeyManager;
            _cache = cache;
        }

        /// <summary>
        /// 获取全部cache key列表
        /// </summary>
        /// <returns></returns>
        public List<Item> GetAll()
        {
            return _cacheKeyManager.CacheList;
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            _cache.RemovePrefix(key);
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        public void Clear()
        {
            _cache.Clear();
        }
    }
}
