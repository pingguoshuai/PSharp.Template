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
    public class SysFileDto : DtoBase {
        /// <summary>
        /// OldName
        /// </summary>
        [Required(ErrorMessage = "OldName不能为空")]
        [StringLength( 300 )]
        [Display( Name = "OldName" )]
        public string OldName { get; set; }
        /// <summary>
        /// NewName
        /// </summary>
        [Required(ErrorMessage = "NewName不能为空")]
        [StringLength(300)]
        [Display( Name = "NewName" )]
        public string NewName { get; set; }
        /// <summary>
        /// Extension
        /// </summary>
        [Required(ErrorMessage = "Extension不能为空")]
        [StringLength( 10 )]
        [Display( Name = "Extension" )]
        public string Extension { get; set; }
        /// <summary>
        /// Size
        /// </summary>
        [Required(ErrorMessage = "Size不能为空")]
        [Display( Name = "Size" )]
        public int Size { get; set; }
        /// <summary>
        /// Md5
        /// </summary>
        [Required(ErrorMessage = "Md5不能为空")]
        [StringLength( 64 )]
        [Display( Name = "Md5" )]
        public string Md5 { get; set; }
        /// <summary>
        /// Src
        /// </summary>
        [Required(ErrorMessage = "Src不能为空")]
        [StringLength( 255 )]
        [Display( Name = "Src" )]
        public string Src { get; set; }
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
        /// 版本号
        /// </summary>
        [Display(Name = "版本号")]
        public Byte[] Version { get; set; }
    }
}