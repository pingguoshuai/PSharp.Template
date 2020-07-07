using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using PSharp.Template.Systems.Services.Dtos;
using Util.Datas.Sql;
using Util.Domains;

namespace PSharp.Template.Systems.Domains.Models
{
    [Table("Systems.RoleInterface")]
    [Description("角色接口")]
    public partial class RoleInterface : EntityBase<RoleInterface>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId">角色标识</param>
        /// <param name="interfaceCode">接口编码</param>
        /// <param name="applicationId">应用程序标识</param>
        public RoleInterface(Guid roleId, string interfaceCode, Guid applicationId) : base(Guid.Empty)
        {
            RoleId = roleId;
            InterfaceCode = interfaceCode;
            ApplicationId = applicationId;
        }

        /// <summary>
        /// 角色标识
        /// </summary>
        [DisplayName("角色标识")]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        /// <summary>
        /// 接口标识
        /// </summary>
        [DisplayName("接口标识")]
        public string InterfaceCode { get; set; }
        [NotMapped]
        [Ignore]
        public InterfaceDto InterfaceDto { get; set; }
        
        /// <summary>
        /// 应用程序标识
        /// </summary>
        [DisplayName("应用程序标识")]
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
