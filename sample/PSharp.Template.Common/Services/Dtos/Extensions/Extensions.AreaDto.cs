using Util;
using Util.Maps;
using PSharp.Template.Common.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Common.Services.Dtos.Extensions {
    /// <summary>
    /// 行政区划参数扩展
    /// </summary>
    public static class AreaDtoExtension {
        /// <summary>
        /// 转换为行政区划实体
        /// </summary>
        /// <param name="dto">行政区划参数</param>
        public static Area ToEntity( this AreaDto dto ) {
            if ( dto == null )
                return new Area();
            return dto.MapTo( new Area( dto.Id.ToInt(), dto.Path, Convert.ToInt(dto.Level) ) );
        }
        
        /// <summary>
        /// 转换为行政区划参数
        /// </summary>
        /// <param name="entity">行政区划实体</param>
        public static AreaDto ToDto(this Area entity) {
            if( entity == null )
                return new AreaDto();
            var result = entity.MapTo<AreaDto>();
            result.Text = entity.Name;
            return result;
        }
    }
}