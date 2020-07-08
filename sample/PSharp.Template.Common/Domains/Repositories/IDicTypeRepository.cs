using System.Threading.Tasks;
using Util.Domains.Repositories;
using Util.Domains.Trees;
using PSharp.Template.Common.Domains.Models;

namespace PSharp.Template.Common.Domains.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IDicTypeRepository : IRepository<DicType> {

        /// <summary>
        /// 是否允许创建字典类型
        /// </summary>
        /// <param name="entity">字典类型</param>
        Task<bool> CanCreateAsync(DicType entity);

        /// <summary>
        /// 是否允许修改字典类型
        /// </summary>
        /// <param name="entity">字典类型</param>
        Task<bool> CanUpdateAsync(DicType entity);
    }
}