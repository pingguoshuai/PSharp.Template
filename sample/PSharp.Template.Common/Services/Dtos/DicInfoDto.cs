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
    public class DicInfoDto : DtoBase {
        /// <summary>
        /// 字典类型标识
        /// </summary>
        [Required(ErrorMessage = "字典类型不能为空")]
        [Display( Name = "字典类型")]
        public Guid DicTypeId { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        [Display(Name = "字典类型")]
        public string DicTypeName { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage = "Name不能为空")]
        [StringLength( 50 )]
        [Display( Name = "Name" )]
        public string Name { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        [Required(ErrorMessage = "Value不能为空")]
        [StringLength( 50 )]
        [Display( Name = "Value" )]
        public string Value { get; set; }
        /// <summary>
        /// Sort
        /// </summary>
        [Required(ErrorMessage = "Sort不能为空")]
        [Display( Name = "Sort" )]
        public int Sort { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [Display( Name = "Status" )]
        public bool? Status { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        [Display(Name = "版本号")]
        public Byte[] Version { get; set; }
    }
}