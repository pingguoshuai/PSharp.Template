using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Systems.Datas.Repositories {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository {
        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApplicationRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}