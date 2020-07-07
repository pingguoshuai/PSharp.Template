using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSharp.Template.Business.Domains.Models;

namespace PSharp.Template.Business.Datas.Mappings.MySql {
    /// <summary>
    /// 栏目映射配置
    /// </summary>
    public class ColumnMap : Util.Datas.Ef.MySql.AggregateRootMap<Column> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Column> builder ) {
            builder.ToTable( "Business.column" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Column> builder ) {
            //Id
            builder.Property(t => t.Id)
                .HasColumnName("Id");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}
