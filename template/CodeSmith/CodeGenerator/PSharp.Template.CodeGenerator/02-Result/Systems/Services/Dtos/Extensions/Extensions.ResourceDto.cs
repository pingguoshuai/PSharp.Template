using Util;
using Util.Maps;
using PSharp.Template.Systems.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Systems.Services.Dtos.Extensions {
    /// <summary>
    /// 身份资源参数扩展
    /// </summary>
    public static class ResourceDtoExtension {
        /// <summary>
        /// 转换为身份资源实体
        /// </summary>
        /// <param name="dto">身份资源参数</param>
        public static Resource ToEntity( this ResourceDto dto ) {
            if ( dto == null )
                return new Resource();
            return dto.MapTo( new Resource( dto.Id.ToGuid(), dto.Path, Convert.ToInt(dto.Level) ) );
        }
        
        /// <summary>
        /// 转换为身份资源参数
        /// </summary>
        /// <param name="entity">身份资源实体</param>
        public static ResourceDto ToDto(this Resource entity) {
            if( entity == null )
                return new ResourceDto();
            return entity.MapTo<ResourceDto>();
        }
    }
}