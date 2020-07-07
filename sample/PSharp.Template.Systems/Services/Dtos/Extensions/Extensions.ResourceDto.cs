using PSharp.Template.Systems.Domains.Enums;
using Util;
using Util.Maps;
using PSharp.Template.Systems.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Systems.Services.Dtos.Extensions {
    /// <summary>
    /// 参数扩展
    /// </summary>
    public static class ResourceDtoExtension {
        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">参数</param>
        public static Resource ToEntity( this ResourceDto dto ) {
            if ( dto == null )
                return new Resource();
            return dto.MapTo( new Resource( dto.Id.ToGuid(), dto.Path, Convert.ToInt(dto.Level) ) );
        }
        
        /// <summary>
        /// 转换为参数
        /// </summary>
        /// <param name="entity">实体</param>
        public static ResourceDto ToDto(this Resource entity) {
            if( entity == null )
                return new ResourceDto();
            var result = entity.MapTo<ResourceDto>();
            result.Text = entity.Name;
            result.Key = entity.Id.ToString();
            result.Value = entity.Id.ToString();
            result.Title = entity.Name;
            result.TypeText = Enum.GetDescription<ResourceType>(result.Type);
            return result;
        }
    }
}