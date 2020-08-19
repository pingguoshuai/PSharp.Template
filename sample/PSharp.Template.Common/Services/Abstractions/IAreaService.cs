using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Applications.Trees;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Dtos.Requests;
using PSharp.Template.Common.Services.Queries;
using AspectCore.DynamicProxy.Parameters;
using EasyCaching.Core.Interceptor;
using Util.Validations.Aspects;
using PSharp.Template.Common.Cache;

namespace PSharp.Template.Common.Services.Abstractions {
    /// <summary>
    /// 行政区划服务
    /// </summary>
    public interface IAreaService : ITreeService<AreaDto, AreaQuery, int?>
    {
        //[EasyCachingAble(Expiration = 7200, CacheKeyPrefix = CacheKeys.AreaListByParent)]
        new Task<List<AreaDto>> QueryAsync(AreaQuery parameter);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<int> CreateAsync([NotNull] [Valid] CreateAreaRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UpdateAsync([NotNull] [Valid] UpdateAreaRequest request);

        /// <summary>
        /// 根据父id查询列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<List<AreaDto>> GetListByPid(int parentId);
    }
}