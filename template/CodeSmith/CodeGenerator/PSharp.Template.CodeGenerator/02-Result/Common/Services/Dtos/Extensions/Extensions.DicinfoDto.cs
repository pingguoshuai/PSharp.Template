using Util;
using Util.Maps;
using PSharp.Template.Common.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Common.Services.Dtos.Extensions {
    /// <summary>
    /// 数据字典参数扩展
    /// </summary>
    public static class DicinfoDtoExtension {
        /// <summary>
        /// 转换为数据字典实体
        /// </summary>
        /// <param name="dto">数据字典参数</param>
        public static Dicinfo ToEntity( this DicinfoDto dto ) {
            if ( dto == null )
                return new Dicinfo();
            return dto.MapTo( new Dicinfo( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为数据字典参数
        /// </summary>
        /// <param name="entity">数据字典实体</param>
        public static DicinfoDto ToDto(this Dicinfo entity) {
            if( entity == null )
                return new DicinfoDto();
            return entity.MapTo<DicinfoDto>();
        }
    }
}