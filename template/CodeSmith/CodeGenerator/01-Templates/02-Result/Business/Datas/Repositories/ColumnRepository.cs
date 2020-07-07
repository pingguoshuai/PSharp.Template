using PSharp.Template.Business.Domains.Models;
using PSharp.Template.Business.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Business.Datas.Repositories {
    /// <summary>
    /// 栏目仓储
    /// </summary>
    public class ColumnRepository : RepositoryBase<Column>, IColumnRepository {
        /// <summary>
        /// 初始化栏目仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ColumnRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}