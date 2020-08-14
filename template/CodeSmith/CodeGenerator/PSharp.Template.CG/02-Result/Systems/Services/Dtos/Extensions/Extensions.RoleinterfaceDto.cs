using Util;
using Util.Maps;
using PSharp.Template.Systems.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Systems.Services.Dtos.Extensions {
    /// <summary>
    /// 角色接口参数扩展
    /// </summary>
    public static class RoleinterfaceDtoExtension {
        /// <summary>
        /// 转换为角色接口实体
        /// </summary>
        /// <param name="dto">角色接口参数</param>
        public static Roleinterface ToEntity( this RoleinterfaceDto dto ) {
            if ( dto == null )
                return new Roleinterface();
            return dto.MapTo( new Roleinterface( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为角色接口参数
        /// </summary>
        /// <param name="entity">角色接口实体</param>
        public static RoleinterfaceDto ToDto(this Roleinterface entity) {
            if( entity == null )
                return new RoleinterfaceDto();
            return entity.MapTo<RoleinterfaceDto>();
        }
    }
}