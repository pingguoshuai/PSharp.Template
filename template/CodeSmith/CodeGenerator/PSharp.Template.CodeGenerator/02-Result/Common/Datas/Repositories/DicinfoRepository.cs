using PSharp.Template.Common.Domains.Models;
using PSharp.Template.Common.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Common.Datas.Repositories {
    /// <summary>
    /// 数据字典仓储
    /// </summary>
    public class DicinfoRepository : RepositoryBase<Dicinfo>, IDicinfoRepository {
        /// <summary>
        /// 初始化数据字典仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DicinfoRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}