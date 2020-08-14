using System;
using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using PSharp.Template.UnitOfWork;
using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Requests;

namespace PSharp.Template.Systems.Services.Implements {
    /// <summary>
    /// 权限服务
    /// </summary>
    public class PermissionService : CrudServiceBase<Permission, PermissionDto, UpdatePermissionRequest, CreatePermissionRequest, UpdatePermissionRequest, PermissionQuery,Guid>, IPermissionService {
        private readonly IArticleRepository _articleRepository;
        
        /// <summary>
        /// 初始化权限服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="permissionRepository">权限仓储</param>
        public PermissionService( IDefaultUnitOfWork unitOfWork, IPermissionRepository permissionRepository )
            : base( unitOfWork, permissionRepository ) {
            _permissionRepository = permissionRepository;
        }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Permission> CreateQuery( PermissionQuery param ) {
            return new Query<Permission>( param );
        }

        protected override Permission ToEntityFromUpdateRequest(UpdatePermissionRequest request)
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