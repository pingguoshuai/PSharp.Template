using Util;
using Util.Maps;
using PSharp.Template.Systems.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Systems.Services.Dtos.Extensions {
    /// <summary>
    /// 管理员参数扩展
    /// </summary>
    public static class UserDtoExtension {
        /// <summary>
        /// 转换为管理员实体
        /// </summary>
        /// <param name="dto">管理员参数</param>
        public static User ToEntity( this UserDto dto ) {
            if ( dto == null )
                return new User();
            return dto.MapTo( new User( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为管理员参数
        /// </summary>
        /// <param name="entity">管理员实体</param>
        public static UserDto ToDto(this User entity) {
            if( entity == null )
                return new UserDto();
            return entity.MapTo<UserDto>();
        }
    }
}