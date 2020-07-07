using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSharp.Template.Business.Domains.Models;

namespace PSharp.Template.Business.Datas.Mappings.MySql {
    /// <summary>
    /// 文章映射配置
    /// </summary>
    public class ArticleMap : Util.Datas.Ef.MySql.AggregateRootMap<Article> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Article> builder ) {
            builder.ToTable( "Business.article" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Article> builder ) {
            //Id
            builder.Property(t => t.Id)
                .HasColumnName("Id");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}
