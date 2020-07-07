using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSharp.Template.Systems.Domains.Models;

namespace PSharp.Template.Systems.Datas.Mappings.SqlServer {
    /// <summary>
    /// 映射配置
    /// </summary>
    public class UserMap : Util.Datas.Ef.SqlServer.AggregateRootMap<User> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<User> builder ) {
            builder.ToTable( "User", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<User> builder ) {
            //Id
            builder.Property(t => t.Id)
                .HasColumnName("Id");
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}
