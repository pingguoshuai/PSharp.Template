using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Data;

namespace PSharp.Template.Systems.Services.Dtos {
    /// <summary>
    /// 角色数据传输对象
    /// </summary>
    public class RoleDto : TreeDto<RoleDto> {
        /// <summary>
        /// Version
        /// </summary>
        [Display( Name = "Version" )]
        public Byte[] Version { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        [Required(ErrorMessage = "Code不能为空")]
        [StringLength( 1024 )]
        [Display( Name = "Code" )]
        public string Code { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "角色名称不能为空")]
        [StringLength( 1024 )]
        [Display( Name = "角色名称" )]
        public string Name { get; set; }
        /// <summary>
        /// NormalizedName
        /// </summary>
        [Required(ErrorMessage = "NormalizedName不能为空")]
        [StringLength( 1024 )]
        [Display( Name = "NormalizedName" )]
        public string NormalizedName { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        [Required(ErrorMessage = "Type不能为空")]
        [StringLength( 320 )]
        [Display( Name = "Type" )]
        public string Type { get; set; }
        /// <summary>
        /// IsAdmin
        /// </summary>
        [Display( Name = "IsAdmin" )]
        public bool? IsAdmin { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        [StringLength( 2000 )]
        [Display( Name = "Remark" )]
        public string Remark { get; set; }
        /// <summary>
        /// PinYin
        /// </summary>
        [StringLength( 800 )]
        [Display( Name = "PinYin" )]
        public string PinYin { get; set; }
        /// <summary>
        /// Sign
        /// </summary>
        [StringLength( 1024 )]
        [Display( Name = "Sign" )]
        public string Sign { get; set; }
        /// <summary>
        /// CreationTime
        /// </summary>
        [Display( Name = "CreationTime" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// CreatorId
        /// </summary>
        [Display( Name = "CreatorId" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// LastModificationTime
        /// </summary>
        [Display( Name = "LastModificationTime" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// LastModifierId
        /// </summary>
        [Display( Name = "LastModifierId" )]
        public Guid? LastModifierId { get; set; }
    }
}