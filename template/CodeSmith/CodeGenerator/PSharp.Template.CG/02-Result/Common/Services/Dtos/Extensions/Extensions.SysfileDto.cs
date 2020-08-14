using Util;
using Util.Maps;
using PSharp.Template.Common.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Common.Services.Dtos.Extensions {
    /// <summary>
    /// 文件参数扩展
    /// </summary>
    public static class SysfileDtoExtension {
        /// <summary>
        /// 转换为文件实体
        /// </summary>
        /// <param name="dto">文件参数</param>
        public static Sysfile ToEntity( this SysfileDto dto ) {
            if ( dto == null )
                return new Sysfile();
            return dto.MapTo( new Sysfile( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为文件参数
        /// </summary>
        /// <param name="entity">文件实体</param>
        public static SysfileDto ToDto(this Sysfile entity) {
            if( entity == null )
                return new SysfileDto();
            return entity.MapTo<SysfileDto>();
        }
    }
}