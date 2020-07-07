using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSharp.Template.Common.Domains.Models;

namespace PSharp.Template.Common.Datas.Mappings.PgSql {
    /// <summary>
    /// 映射配置
    /// </summary>
    public class SysFileMap : Util.Datas.Ef.PgSql.AggregateRootMap<SysFile> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<SysFile> builder ) {
            builder.ToTable( "SysFile", "Common" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<SysFile> builder ) {
            //Id
            builder.Property(t => t.Id)
                .HasColumnName("Id");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}
