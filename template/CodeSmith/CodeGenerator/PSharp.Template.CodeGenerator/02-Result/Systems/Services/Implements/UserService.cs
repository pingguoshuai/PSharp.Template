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
    /// 管理员服务
    /// </summary>
    public class UserService : CrudServiceBase<User, UserDto, UpdateUserRequest, CreateUserRequest, UpdateUserRequest, UserQuery,Guid>, IUserService {
        private readonly IArticleRepository _articleRepository;
        
        /// <summary>
        /// 初始化管理员服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="userRepository">管理员仓储</param>
        public UserService( IDefaultUnitOfWork unitOfWork, IUserRepository userRepository )
            : base( unitOfWork, userRepository ) {
            _userRepository = userRepository;
        }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<User> CreateQuery( UserQuery param ) {
            return new Query<User>( param );
        }

        protected override User ToEntityFromUpdateRequest(UpdateUserRequest request)
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