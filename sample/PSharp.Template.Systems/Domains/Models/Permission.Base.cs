
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Util.Domains;
using Util.Domains.Auditing;

namespace PSharp.Template.Systems.Domains.Models
{
    [Table("Systems.Permission")]
    [Description("权限")]
    public partial class Permission : AggregateRoot<Permission>, IDelete, IAudited
    {
        /// <summary>
        /// 初始化权限
        /// </summary>
        public Permission() : this(Guid.Empty)
        {
        }

        /// <summary>
        /// 初始化权限
        /// </summary>
        /// <param name="id">权限标识</param>
        public Permission(Guid id) : base(id)
        {
        }

        /// <summary>
        /// 角色标识
        /// </summary>
        [DisplayName("角色标识")]
        [Required(ErrorMessage = "角色标识不能为空")]
        public Guid RoleId { get; set; }
        /// <summary>
        /// 资源标识
        /// </summary>
        [DisplayName("资源标识")]
        [Required(ErrorMessage = "资源标识不能为空")]
        public Guid ResourceId { get; set; }
        /// <summary>
        /// 拒绝
        /// </summary>
        [DisplayName("拒绝")]
        public bool IsDeny { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        [DisplayName("签名")]
        [StringLength(256)]
        public string Sign { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        /// </summary>
        [DisplayName("创建人标识")]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        /// </summary>
        [DisplayName("最后修改人标识")]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [DisplayName("是否删除")]
        public bool IsDeleted { get; set; }
    }
}
