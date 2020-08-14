using Util;
using Util.Maps;
using PSharp.Template.Systems.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Systems.Services.Dtos.Extensions {
    /// <summary>
    /// 角色参数扩展
    /// </summary>
    public static class RoleDtoExtension {
        /// <summary>
        /// 转换为角色实体
        /// </summary>
        /// <param name="dto">角色参数</param>
        public static Role ToEntity( this RoleDto dto ) {
            if ( dto == null )
                return new Role();
            return dto.MapTo( new Role( dto.Id.ToGuid(), dto.Path, Convert.ToInt(dto.Level) ) );
        }
        
        /// <summary>
        /// 转换为角色参数
        /// </summary>
        /// <param name="entity">角色实体</param>
        public static RoleDto ToDto(this Role entity) {
            if( entity == null )
                return new RoleDto();
            return entity.MapTo<RoleDto>();
        }
    }
}