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
    /// 字典类型服务
    /// </summary>
    public class DictypeService : CrudServiceBase<Dictype, DictypeDto, UpdateDictypeRequest, CreateDictypeRequest, UpdateDictypeRequest, DictypeQuery,Guid>, IDictypeService {
        private readonly IArticleRepository _articleRepository;
        
        /// <summary>
        /// 初始化字典类型服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="dictypeRepository">字典类型仓储</param>
        public DictypeService( IDefaultUnitOfWork unitOfWork, IDictypeRepository dictypeRepository )
            : base( unitOfWork, dictypeRepository ) {
            _dictypeRepository = dictypeRepository;
        }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Dictype> CreateQuery( DictypeQuery param ) {
            return new Query<Dictype>( param );
        }

        protected override Dictype ToEntityFromUpdateRequest(UpdateDictypeRequest request)
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