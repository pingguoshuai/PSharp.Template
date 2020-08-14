using PSharp.Template.Common.Domains.Models;
using PSharp.Template.Common.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Common.Datas.Repositories {
    /// <summary>
    /// 字典类型仓储
    /// </summary>
    public class DictypeRepository : RepositoryBase<Dictype>, IDictypeRepository {
        /// <summary>
        /// 初始化字典类型仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DictypeRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}