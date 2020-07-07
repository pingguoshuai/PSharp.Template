using System;
using System.Threading.Tasks;
using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using PSharp.Template.UnitOfWork;
using PSharp.Template.Common.Domains.Models;
using PSharp.Template.Common.Domains.Repositories;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Queries;
using PSharp.Template.Common.Services.Abstractions;
using PSharp.Template.Common.Services.Dtos.Requests;

namespace PSharp.Template.Common.Services.Implements {
    /// <summary>
    /// 服务
    /// </summary>
    public class DicTypeService : CrudServiceBase<DicType, DicTypeDto, CreateDicTypeRequest, DicTypeQuery,Guid>, IDicTypeService {
        /// <summary>
        /// 初始化服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="dicTypeRepository">仓储</param>
        public DicTypeService( IDefaultUnitOfWork unitOfWork, IDicTypeRepository dicTypeRepository )
            : base( unitOfWork, dicTypeRepository ) {
            DicTypeRepository = dicTypeRepository;
        }
        
        /// <summary>
        /// 仓储
        /// </summary>
        public IDicTypeRepository DicTypeRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<DicType> CreateQuery( DicTypeQuery param ) {
            var query = new Query<DicType>(param);
            if (param.Status != null)
            {
                query.Where(t => t.Status.Equals(param.Status));
            }
            query.WhereIfNotEmpty(t => t.Name.Contains(param.Name))
                .WhereIfNotEmpty(t => t.Code.Contains(param.Code))
                //.WhereIfNotEmpty(t=>t.Status.Equals(param.Status))
                .OrderBy(t => t.CreationTime, true);
            return query;
        }

        protected override DicType ToEntityFromUpdateRequest(CreateDicTypeRequest request)
        {
            var oldEntity = FindOldEntity(request.Id.ToGuid());
            if (oldEntity == null)
            {
                return base.ToEntityFromUpdateRequest(request);
            }

            request.MapTo(oldEntity);
            return oldEntity;
        }
    }
}