using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Applications.Trees;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Dtos.Requests;
using PSharp.Template.Systems.Services.Queries;
using Util.Aspects;
using Util.Validations.Aspects;

namespace PSharp.Template.Systems.Services.Abstractions {
    /// <summary>
    /// 服务
    /// </summary>
    public interface IResourceService : ITreeService<ResourceDto, ResourceQuery>
    {
        /// <summary>
        /// 创建资源
        /// </summary>
        /// <param name="request">创建资源参数</param>
        Task<Guid> CreateAsync([NotNull][Valid] CreateResourceRequest request);

        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="request">模块参数</param>
        Task UpdateAsync([NotNull][Valid] ResourceDto request);

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        Task<List<ResourceDto>> GetMenuAsync();
    }
}