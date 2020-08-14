using System;
using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using PSharp.Template.UnitOfWork;
using PSharp.Template.Business.Domains.Models;
using PSharp.Template.Business.Domains.Repositories;
using PSharp.Template.Business.Services.Dtos;
using PSharp.Template.Business.Services.Queries;
using PSharp.Template.Business.Services.Abstractions;
using PSharp.Template.Business.Services.Dtos.Requests;

namespace PSharp.Template.Business.Services.Implements {
    /// <summary>
    /// 栏目服务
    /// </summary>
    public class ColumnService : CrudServiceBase<Column, ColumnDto, UpdateColumnRequest, CreateColumnRequest, UpdateColumnRequest, ColumnQuery,Guid>, IColumnService {
        private readonly IArticleRepository _articleRepository;
        
        /// <summary>
        /// 初始化栏目服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="columnRepository">栏目仓储</param>
        public ColumnService( IDefaultUnitOfWork unitOfWork, IColumnRepository columnRepository )
            : base( unitOfWork, columnRepository ) {
            _columnRepository = columnRepository;
        }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Column> CreateQuery( ColumnQuery param ) {
            return new Query<Column>( param );
        }

        protected override Column ToEntityFromUpdateRequest(UpdateColumnRequest request)
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