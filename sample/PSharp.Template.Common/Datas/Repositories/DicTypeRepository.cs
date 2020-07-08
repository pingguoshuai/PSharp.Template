using System;
using System.Threading.Tasks;
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

        /// <summary>
        /// 是否允许创建字典类型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> CanCreateAsync(DicType entity)
        {
            var exists = await ExistsAsync(t => t.Code.Equals(entity.Code, StringComparison.OrdinalIgnoreCase));
            return exists == false;
        }

        /// <summary>
        /// 是否允许修改字典类型
        /// </summary>
        /// <param name="entity">字典类型</param>
        public async Task<bool> CanUpdateAsync(DicType entity)
        {
            var exists = await ExistsAsync(t => t.Id != entity.Id && t.Code.Equals(entity.Code, StringComparison.OrdinalIgnoreCase));
            return exists == false;
        }
    }
}