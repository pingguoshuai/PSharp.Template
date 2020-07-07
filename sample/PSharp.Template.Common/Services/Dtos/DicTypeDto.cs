using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;

namespace PSharp.Template.Common.Services.Dtos {
    /// <summary>
    /// 参数
    /// </summary>
    public class DicTypeDto : DtoBase {
        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage = "Name不能为空")]
        [StringLength( 50 )]
        [Display( Name = "Name" )]
        public string Name { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        [Required(ErrorMessage = "Code不能为空")]
        [StringLength( 50 )]
        [Display( Name = "Code" )]
        public string Code { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [Display( Name = "Status" )]
        public bool? Status { get; set; }
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
        /// <summary>
        /// 版本号
        /// </summary>
        [Display(Name = "版本号")]
        public Byte[] Version { get; set; }
    }
}