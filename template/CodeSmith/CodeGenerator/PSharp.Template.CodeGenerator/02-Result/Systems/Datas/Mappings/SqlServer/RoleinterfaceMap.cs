using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSharp.Template.Systems.Domains.Models;

namespace PSharp.Template.Systems.Datas.Mappings.SqlServer {
    /// <summary>
    /// 角色接口映射配置
    /// </summary>
    public class RoleinterfaceMap : Util.Datas.Ef.SqlServer.AggregateRootMap<Roleinterface> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Roleinterface> builder ) {
            builder.ToTable( "roleinterface", "Systems" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Roleinterface> builder ) {
            //Id
            builder.Property(t => t.Id)
                .HasColumnName("Id");
        }
    }
}
