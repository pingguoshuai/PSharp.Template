using System;
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
    /// 数据字典服务
    /// </summary>
    public class DicinfoService : CrudServiceBase<Dicinfo, DicinfoDto, UpdateDicinfoRequest, CreateDicinfoRequest, UpdateDicinfoRequest, DicinfoQuery,Guid>, IDicinfoService {
        private readonly IArticleRepository _articleRepository;
        
        /// <summary>
        /// 初始化数据字典服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="dicinfoRepository">数据字典仓储</param>
        public DicinfoService( IDefaultUnitOfWork unitOfWork, IDicinfoRepository dicinfoRepository )
            : base( unitOfWork, dicinfoRepository ) {
            _dicinfoRepository = dicinfoRepository;
        }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Dicinfo> CreateQuery( DicinfoQuery param ) {
            return new Query<Dicinfo>( param );
        }

        protected override Dicinfo ToEntityFromUpdateRequest(UpdateDicinfoRequest request)
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