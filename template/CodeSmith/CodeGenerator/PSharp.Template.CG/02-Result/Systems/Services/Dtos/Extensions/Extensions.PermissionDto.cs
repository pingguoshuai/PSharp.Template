using Util;
using Util.Maps;
using PSharp.Template.Systems.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Systems.Services.Dtos.Extensions {
    /// <summary>
    /// 权限参数扩展
    /// </summary>
    public static class PermissionDtoExtension {
        /// <summary>
        /// 转换为权限实体
        /// </summary>
        /// <param name="dto">权限参数</param>
        public static Permission ToEntity( this PermissionDto dto ) {
            if ( dto == null )
                return new Permission();
            return dto.MapTo( new Permission( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为权限参数
        /// </summary>
        /// <param name="entity">权限实体</param>
        public static PermissionDto ToDto(this Permission entity) {
            if( entity == null )
                return new PermissionDto();
            return entity.MapTo<PermissionDto>();
        }
    }
}