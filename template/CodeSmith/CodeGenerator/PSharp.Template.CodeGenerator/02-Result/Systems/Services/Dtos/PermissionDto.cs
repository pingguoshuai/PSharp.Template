using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;

namespace PSharp.Template.Systems.Services.Dtos {
    /// <summary>
    /// 权限参数
    /// </summary>
    public class PermissionDto : DtoBase {
        /// <summary>
        /// Version
        /// </summary>
        [Display( Name = "Version" )]
        public Byte[] Version { get; set; }
        /// <summary>
        /// 角色标识
        /// </summary>
        [Required(ErrorMessage = "角色标识不能为空")]
        [Display( Name = "角色标识" )]
        public Guid RoleId { get; set; }
        /// <summary>
        /// 资源标识
        /// </summary>
        [Required(ErrorMessage = "资源标识不能为空")]
        [Display( Name = "资源标识" )]
        public Guid ResourceId { get; set; }
        /// <summary>
        /// 拒绝
        /// </summary>
        [Display( Name = "拒绝" )]
        public bool? IsDeny { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        [StringLength( 1024 )]
        [Display( Name = "签名" )]
        public string Sign { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display( Name = "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        /// </summary>
        [Display( Name = "创建人标识" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Display( Name = "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        /// </summary>
        [Display( Name = "最后修改人标识" )]
        public Guid? LastModifierId { get; set; }
    }
}