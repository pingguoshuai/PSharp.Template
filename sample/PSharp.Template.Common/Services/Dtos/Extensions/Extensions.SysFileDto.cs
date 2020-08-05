using Util;
using Util.Maps;
using PSharp.Template.Common.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Common.Services.Dtos.Extensions {
    /// <summary>
    /// 参数扩展
    /// </summary>
    public static class SysFileDtoExtension {
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">参数</param>
        public static SysFile ToEntity( this SysFileDto dto ) {
            if ( dto == null )
                return new SysFile();
            return dto.MapTo( new SysFile( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为参数
        /// </summary>
        /// <param name="entity">实体</param>
        public static SysFileDto ToDto(this SysFile entity) {
            if (entity == null)
                return null;
            var result = entity.MapTo<SysFileDto>();
            result.Src = string.IsNullOrEmpty(result.Src) ? result.Src : Core.Helper.Web.GetHttpAndHost() + result.Src;
            return result;
        }
    }
}