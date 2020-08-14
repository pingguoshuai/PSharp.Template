using Util.Applications.Trees;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;

namespace PSharp.Template.Systems.Services.Abstractions {
    /// <summary>
    /// 身份资源服务
    /// </summary>
    public interface IResourceService : ITreeService<ResourceDto, ResourceQuery> {
    }
}