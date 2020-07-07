using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSharp.Template.Systems.Domains.Models;

namespace PSharp.Template.Systems.Datas.Mappings.SqlServer {
    /// <summary>
    /// 权限映射配置
    /// </summary>
    public class PermissionMap : Util.Datas.Ef.SqlServer.AggregateRootMap<Permission> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Permission> builder ) {
            builder.ToTable( "permission", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Permission> builder ) {
            //Id
            builder.Property(t => t.Id)
                .HasColumnName("Id");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}
