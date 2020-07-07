using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSharp.Template.Common.Domains.Models;

namespace PSharp.Template.Common.Datas.Mappings.SqlServer {
    /// <summary>
    /// 映射配置
    /// </summary>
    public class DicTypeMap : Util.Datas.Ef.SqlServer.AggregateRootMap<DicType> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<DicType> builder ) {
            builder.ToTable( "DicType", "Common" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<DicType> builder ) {
            //Id
            builder.Property(t => t.Id)
                .HasColumnName("Id");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}
