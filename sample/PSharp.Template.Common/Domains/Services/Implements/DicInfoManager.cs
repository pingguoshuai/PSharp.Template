using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using PSharp.Template.Common.Cache;
using PSharp.Template.Common.Domains.Models;
using PSharp.Template.Common.Domains.Repositories;
using PSharp.Template.Common.Domains.Services.Abstractions;
using PSharp.Template.Core.Caches;
using Microsoft.EntityFrameworkCore;
using Util;
using Util.Datas.Queries;
using Util.Domains.Services;

namespace PSharp.Template.Common.Domains.Services.Implements
{
    public class DicInfoManager : DomainServiceBase, IDicInfoManager
    {
        private readonly IDicInfoRepository _dicInfoRepository;
        private readonly ICache _cache;

        public DicInfoManager(IDicInfoRepository dicInfoRepository, ICache cache)
        {
            _dicInfoRepository = dicInfoRepository;
            _cache = cache;
        }

        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<DicInfo> GetById(Guid? key)
        {
            key.CheckNull(nameof(key));
            return await _dicInfoRepository.FindAsync(key);
        }

        /// <summary>
        /// 根据value 和 父code查询实体
        /// </summary>
        /// <param name="typecode"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<DicInfo> GetByCodeAndValue(string typecode, string value)
        {
            value.CheckNull(nameof(value));
            var list = await GetListByTypeCode(typecode);
            if (list.Count > 0)
            {
                return list.FirstOrDefault(t => t.Value.Equals(value));
            }

            return null;
        }

        /// <summary>
        /// 根据父code 查询列表
        /// </summary>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        public async Task<List<DicInfo>> GetListByTypeCode(string typeCode)
        {
            typeCode.CheckNull(nameof(typeCode));
            if (!_cache.Exists($"{CacheKeys.DicInfoListByCode}{typeCode}"))
            {
                var query = new Query<DicInfo>();
                query.Where(t => t.DicType.Code.Equals(typeCode));
                query.Where(t => t.Status.Equals(true));
                query.OrderBy("Sort", true);
                query.OrderBy("CreationTime");

                var list = (await _dicInfoRepository.Find().Where(query).Include(t => t.DicType).OrderBy(query.GetOrder())
                    .ToListAsync());
                if (list.Count > 0) _cache.TryAdd($"{CacheKeys.DicInfoListByCode}{typeCode}", list);
                return list;
            }

            return _cache.Get<List<DicInfo>>($"{CacheKeys.DicInfoListByCode}{typeCode}", () => null);
        }
    }
}
