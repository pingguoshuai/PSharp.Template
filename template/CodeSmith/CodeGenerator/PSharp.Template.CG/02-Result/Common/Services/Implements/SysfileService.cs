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
    /// 文件服务
    /// </summary>
    public class SysfileService : CrudServiceBase<Sysfile, SysfileDto, UpdateSysfileRequest, CreateSysfileRequest, UpdateSysfileRequest, SysfileQuery,Guid>, ISysfileService {
        private readonly IArticleRepository _articleRepository;
        
        /// <summary>
        /// 初始化文件服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="sysfileRepository">文件仓储</param>
        public SysfileService( IDefaultUnitOfWork unitOfWork, ISysfileRepository sysfileRepository )
            : base( unitOfWork, sysfileRepository ) {
            _sysfileRepository = sysfileRepository;
        }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Sysfile> CreateQuery( SysfileQuery param ) {
            return new Query<Sysfile>( param );
        }

        protected override Sysfile ToEntityFromUpdateRequest(UpdateSysfileRequest request)
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