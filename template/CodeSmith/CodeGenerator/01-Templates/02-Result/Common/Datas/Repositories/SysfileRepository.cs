using PSharp.Template.Common.Domains.Models;
using PSharp.Template.Common.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Common.Datas.Repositories {
    /// <summary>
    /// 文件仓储
    /// </summary>
    public class SysfileRepository : RepositoryBase<Sysfile>, ISysfileRepository {
        /// <summary>
        /// 初始化文件仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public SysfileRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}