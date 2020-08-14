using Util;
using Util.Maps;
using PSharp.Template.Business.Domains.Models;
using Util.Helpers;

namespace PSharp.Template.Business.Services.Dtos.Extensions {
    /// <summary>
    /// 文章参数扩展
    /// </summary>
    public static class ArticleDtoExtension {
        /// <summary>
        /// 转换为文章实体
        /// </summary>
        /// <param name="dto">文章参数</param>
        public static Article ToEntity( this ArticleDto dto ) {
            if ( dto == null )
                return new Article();
            return dto.MapTo( new Article( dto.Id.ToGuid() ) );
        }
        
        /// <summary>
        /// 转换为文章参数
        /// </summary>
        /// <param name="entity">文章实体</param>
        public static ArticleDto ToDto(this Article entity) {
            if( entity == null )
                return new ArticleDto();
            return entity.MapTo<ArticleDto>();
        }
    }
}