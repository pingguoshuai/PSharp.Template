using Util.Domains.Repositories;
using Util.Domains.Trees;
using PSharp.Template.Common.Domains.Models;

namespace PSharp.Template.Common.Domains.Repositories {
    /// <summary>
    /// 行政区划仓储
    /// </summary>
    public interface IAreaRepository : ITreeRepository<Area,int,int?> {
    }
}
