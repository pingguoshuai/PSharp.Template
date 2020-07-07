using Util;
using Util.Maps;
using PSharp.Template.Common.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Common.Services.Dtos.Extensions {
    /// <summary>
    /// 参数扩展
    /// </summary>
    public static class DicInfoDtoExtension {
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">参数</param>
        public static DicInfo ToEntity( this DicInfoDto dto ) {
            if ( dto == null )
                return new DicInfo();
            return dto.MapTo( new DicInfo( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为参数
        /// </summary>
        /// <param name="entity">实体</param>
        public static DicInfoDto ToDto(this DicInfo entity) {
            if( entity == null )
                return new DicInfoDto();
            return entity.MapTo<DicInfoDto>();
        }
    }
}