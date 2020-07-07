using System;
using System.Collections.Generic;
using System.Text;
using PSharp.Template.Systems.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PSharp.Template.Systems.Datas.Mappings.MySql
{
    public class UserRoleMap : Util.Datas.Ef.MySql.EntityMap<UserRole>
    {
        protected override void MapTable(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("Systems.UserRole");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(t => new { t.UserId, t.RoleId });
        }
    }
}
