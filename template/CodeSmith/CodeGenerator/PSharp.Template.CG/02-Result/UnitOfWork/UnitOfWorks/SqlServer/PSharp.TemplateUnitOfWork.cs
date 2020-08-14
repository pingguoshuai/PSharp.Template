using Microsoft.EntityFrameworkCore;
using Util.Datas.UnitOfWorks;

namespace Default.Data.UnitOfWorks.SqlServer {
    /// <summary>
    /// 工作单元
    /// </summary>
    public class PSharp.TemplateUnitOfWork : Util.Datas.Ef.SqlServer.UnitOfWork,IPSharp.TemplateUnitOfWork {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        public PSharp.TemplateUnitOfWork( DbContextOptions<PSharp.TemplateUnitOfWork> options ) : base( options ) {
        }
    }
}