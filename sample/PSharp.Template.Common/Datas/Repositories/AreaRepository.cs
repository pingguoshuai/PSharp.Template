using System.Threading.Tasks;
using PSharp.Template.Common.Domains.Models;
using PSharp.Template.Common.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Util;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Common.Datas.Repositories {
    /// <summary>
    /// 行政区划仓储
    /// </summary>
    public class AreaRepository : TreeRepositoryBase<Area, int, int?>, IAreaRepository
    {
        /// <summary>
        /// 初始化行政区划仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public AreaRepository(IDefaultUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<int> GenerateSortIdAsync(int? parentId)
        {
            var maxSortId = await Find(t => t.ParentId == parentId).MaxAsync(t => t.SortId);
            return maxSortId.SafeValue() + 1;
        }
    }
}
