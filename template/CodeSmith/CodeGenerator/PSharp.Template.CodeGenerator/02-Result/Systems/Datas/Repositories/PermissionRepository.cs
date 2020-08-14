using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Systems.Datas.Repositories {
    /// <summary>
    /// 权限仓储
    /// </summary>
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository {
        /// <summary>
        /// 初始化权限仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public PermissionRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}