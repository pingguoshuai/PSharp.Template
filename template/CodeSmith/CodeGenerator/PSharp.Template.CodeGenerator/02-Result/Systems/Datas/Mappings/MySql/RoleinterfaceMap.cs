using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSharp.Template.Systems.Domains.Models;

namespace PSharp.Template.Systems.Datas.Mappings.MySql {
    /// <summary>
    /// 角色接口映射配置
    /// </summary>
    public class RoleinterfaceMap : Util.Datas.Ef.MySql.AggregateRootMap<Roleinterface> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Roleinterface> builder ) {
            builder.ToTable( "Systems.roleinterface" );
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
