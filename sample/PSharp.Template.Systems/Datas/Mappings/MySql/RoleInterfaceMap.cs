﻿using System;
using System.Collections.Generic;
using System.Text;
using PSharp.Template.Systems.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PSharp.Template.Systems.Datas.Mappings.MySql
{
    public class RoleInterfaceMap : Util.Datas.Ef.MySql.EntityMap<RoleInterface>
    {
        protected override void MapTable(EntityTypeBuilder<RoleInterface> builder)
        {
            builder.ToTable("Systems.RoleInterface");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<RoleInterface> builder)
        {
            //builder.HasKey(t => new { t.RoleId, t.ApplicationId });
            builder.Property(t => t.Id)
                .HasColumnName("Id");
        }
    }
}
