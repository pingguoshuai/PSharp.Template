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
    /// 角色接口服务
    /// </summary>
    public class RoleinterfaceService : CrudServiceBase<Roleinterface, RoleinterfaceDto, UpdateRoleinterfaceRequest, CreateRoleinterfaceRequest, UpdateRoleinterfaceRequest, RoleinterfaceQuery,Guid>, IRoleinterfaceService {
        private readonly IArticleRepository _articleRepository;
        
        /// <summary>
        /// 初始化角色接口服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="roleinterfaceRepository">角色接口仓储</param>
        public RoleinterfaceService( IDefaultUnitOfWork unitOfWork, IRoleinterfaceRepository roleinterfaceRepository )
            : base( unitOfWork, roleinterfaceRepository ) {
            _roleinterfaceRepository = roleinterfaceRepository;
        }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Roleinterface> CreateQuery( RoleinterfaceQuery param ) {
            return new Query<Roleinterface>( param );
        }

        protected override Roleinterface ToEntityFromUpdateRequest(UpdateRoleinterfaceRequest request)
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