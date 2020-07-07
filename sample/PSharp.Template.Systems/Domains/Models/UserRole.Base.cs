using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Util.Domains;

namespace PSharp.Template.Systems.Domains.Models
{
    [Table("Systems.UserRole")]
    [Description("用户角色")]
    public partial class UserRole : DomainBase<UserRole>
    {
        /// <summary>
        /// 初始化用户角色
        /// </summary>
        /// <param name="userId">管理员标识</param>
        /// <param name="roleId">角色标识</param>
        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        /// <summary>
        /// 管理员标识
        /// </summary>
        public Guid UserId { get; set; }
        public User User { get; set; }

        /// <summary>
        /// 角色标识
        /// </summary>
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
