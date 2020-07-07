using Util.Domains.Repositories;
using Util.Domains.Trees;
using PSharp.Template.Systems.Domains.Models;

namespace PSharp.Template.Systems.Domains.Repositories {
    /// <summary>
    /// 身份资源仓储
    /// </summary>
    public interface IResourceRepository : ITreeRepository<Resource> {
    }
}
