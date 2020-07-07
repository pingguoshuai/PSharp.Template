using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSharp.Template.Systems.Domains.Models;

namespace PSharp.Template.Systems.Datas.Mappings.PgSql {
    /// <summary>
    /// 身份资源映射配置
    /// </summary>
    public class ResourceMap : Util.Datas.Ef.PgSql.AggregateRootMap<Resource> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Resource> builder ) {
            builder.ToTable( "resource", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Resource> builder ) {
            //Id
            builder.Property(t => t.Id)
                .HasColumnName("Id");
            builder.HasQueryFilter( t => t.IsDeleted == false );
            builder.Property( t => t.Path ).HasColumnName( "Path" );
            builder.Property( t => t.Level ).HasColumnName( "Level" );
        }
    }
}
