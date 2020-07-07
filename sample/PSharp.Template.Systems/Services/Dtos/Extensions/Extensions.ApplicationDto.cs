using Util;
using Util.Maps;
using PSharp.Template.Systems.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Systems.Services.Dtos.Extensions {
    /// <summary>
    /// 参数扩展
    /// </summary>
    public static class ApplicationDtoExtension {
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">参数</param>
        public static Application ToEntity( this ApplicationDto dto ) {
            if ( dto == null )
                return new Application();
            return dto.MapTo( new Application( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为参数
        /// </summary>
        /// <param name="entity">实体</param>
        public static ApplicationDto ToDto(this Application entity) {
            if( entity == null )
                return new ApplicationDto();
            return entity.MapTo<ApplicationDto>();
        }
    }
}