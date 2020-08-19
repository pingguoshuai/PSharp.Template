using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyCaching.Core.Interceptor;
using PSharp.Template.Common.Cache;
using PSharp.Template.Common.Domains.Models;
using Util.Domains.Services;

namespace PSharp.Template.Common.Domains.Services.Abstractions
{
    public interface IAreaManager : IDomainService
    {
        /// <summary>
        /// 根据父Id获取
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [EasyCachingAble(CacheKeyPrefix = CacheKeys.AreaListByParent)]
        Task<List<Area>> GetListByPid(int parentId);
    }
}
