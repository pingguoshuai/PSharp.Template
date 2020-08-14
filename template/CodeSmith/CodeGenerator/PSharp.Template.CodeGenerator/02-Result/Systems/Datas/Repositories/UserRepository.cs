using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Systems.Datas.Repositories {
    /// <summary>
    /// 管理员仓储
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository {
        /// <summary>
        /// 初始化管理员仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public UserRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}