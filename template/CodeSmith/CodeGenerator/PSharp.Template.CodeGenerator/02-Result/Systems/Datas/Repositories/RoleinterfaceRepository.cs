using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Systems.Datas.Repositories {
    /// <summary>
    /// 角色接口仓储
    /// </summary>
    public class RoleinterfaceRepository : RepositoryBase<Roleinterface>, IRoleinterfaceRepository {
        /// <summary>
        /// 初始化角色接口仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public RoleinterfaceRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}