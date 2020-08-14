using Util;
using Util.Maps;
using PSharp.Template.Business.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Business.Services.Dtos.Extensions {
    /// <summary>
    /// 栏目参数扩展
    /// </summary>
    public static class ColumnDtoExtension {
        /// <summary>
        /// 转换为栏目实体
        /// </summary>
        /// <param name="dto">栏目参数</param>
        public static Column ToEntity( this ColumnDto dto ) {
            if ( dto == null )
                return new Column();
            return dto.MapTo( new Column( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为栏目参数
        /// </summary>
        /// <param name="entity">栏目实体</param>
        public static ColumnDto ToDto(this Column entity) {
            if( entity == null )
                return new ColumnDto();
            return entity.MapTo<ColumnDto>();
        }
    }
}