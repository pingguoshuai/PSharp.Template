using Util;
using Util.Maps;
using PSharp.Template.Common.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Common.Services.Dtos.Extensions {
    /// <summary>
    /// 参数扩展
    /// </summary>
    public static class DicTypeDtoExtension {
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">参数</param>
        public static DicType ToEntity( this DicTypeDto dto ) {
            if ( dto == null )
                return new DicType();
            return dto.MapTo( new DicType( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为参数
        /// </summary>
        /// <param name="entity">实体</param>
        public static DicTypeDto ToDto(this DicType entity) {
            if( entity == null )
                return new DicTypeDto();
            return entity.MapTo<DicTypeDto>();
        }
    }
}