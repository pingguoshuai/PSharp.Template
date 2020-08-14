using Util;
using Util.Maps;
using PSharp.Template.Common.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Common.Services.Dtos.Extensions {
    /// <summary>
    /// 字典类型参数扩展
    /// </summary>
    public static class DictypeDtoExtension {
        /// <summary>
        /// 转换为字典类型实体
        /// </summary>
        /// <param name="dto">字典类型参数</param>
        public static Dictype ToEntity( this DictypeDto dto ) {
            if ( dto == null )
                return new Dictype();
            return dto.MapTo( new Dictype( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为字典类型参数
        /// </summary>
        /// <param name="entity">字典类型实体</param>
        public static DictypeDto ToDto(this Dictype entity) {
            if( entity == null )
                return new DictypeDto();
            return entity.MapTo<DictypeDto>();
        }
    }
}