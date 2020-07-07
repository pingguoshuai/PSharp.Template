using PSharp.Template.Common.Domains.Models;
using PSharp.Template.Common.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Common.Datas.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public class DicTypeRepository : RepositoryBase<DicType>, IDicTypeRepository {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DicTypeRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}