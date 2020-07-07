using PSharp.Template.Business.Domains.Models;
using PSharp.Template.Business.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Business.Datas.Repositories {
    /// <summary>
    /// 文章仓储
    /// </summary>
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository {
        /// <summary>
        /// 初始化文章仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ArticleRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}