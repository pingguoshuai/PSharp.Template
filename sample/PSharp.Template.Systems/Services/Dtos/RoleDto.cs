using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Data;

namespace PSharp.Template.Systems.Services.Dtos {
    /// <summary>
    /// 数据传输对象
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
        [StringLength( 256 )]
        [Display( Name = "Code" )]
        public string Code { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage = "Name不能为空")]
        [StringLength( 256 )]
        [Display( Name = "Name" )]
        public string Name { get; set; }
        /// <summary>
        /// NormalizedName
        /// </summary>
        [Required(ErrorMessage = "NormalizedName不能为空")]
        [StringLength( 256 )]
        [Display( Name = "NormalizedName" )]
        public string NormalizedName { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        [Required(ErrorMessage = "Type不能为空")]
        [StringLength( 80 )]
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
        [StringLength( 500 )]
        [Display( Name = "Remark" )]
        public string Remark { get; set; }
        /// <summary>
        /// PinYin
        /// </summary>
        [StringLength( 200 )]
        [Display( Name = "PinYin" )]
        public string PinYin { get; set; }
        /// <summary>
        /// Sign
        /// </summary>
        [StringLength( 256 )]
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