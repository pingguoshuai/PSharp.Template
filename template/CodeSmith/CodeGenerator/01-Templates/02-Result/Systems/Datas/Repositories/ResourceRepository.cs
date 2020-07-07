using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Systems.Datas.Repositories {
    /// <summary>
    /// 身份资源仓储
    /// </summary>
    public class ResourceRepository : TreeRepositoryBase<Resource>, IResourceRepository {
        /// <summary>
        /// 初始化身份资源仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ResourceRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
