﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSharp.Template.Common.Domains.Models;

namespace PSharp.Template.Common.Datas.Mappings.MySql {
    /// <summary>
    /// 映射配置
    /// </summary>
    public class DicInfoMap : Util.Datas.Ef.MySql.AggregateRootMap<DicInfo> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<DicInfo> builder ) {
            builder.ToTable( "Common.DicInfo" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<DicInfo> builder ) {
            //Id
            builder.Property(t => t.Id)
                .HasColumnName("Id");
            builder.HasQueryFilter( t => t.IsDeleted == false && !t.DicType.IsDeleted);
        }
    }
}
