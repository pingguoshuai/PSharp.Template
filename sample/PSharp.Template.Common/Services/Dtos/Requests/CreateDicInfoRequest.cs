using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using PSharp.Template.Core.Applications.Dtos;

namespace PSharp.Template.Common.Services.Dtos.Requests {
    /// <summary>
    /// 字典参数
    /// </summary>
    public class CreateDicInfoRequest : RequestBase {
        /// <summary>
        /// 字典类型
        /// </summary>
        [Required(ErrorMessage = "DicTypeId不能为空")]
        [Display( Name = "DicTypeId" )]
        public Guid DicTypeId { get; set; }
        /// <summary>
        /// 字典名称
        /// </summary>
        [Required(ErrorMessage = "Name不能为空")]
        [StringLength( 50 )]
        [Display( Name = "Name" )]
        public string Name { get; set; }
        /// <summary>
        /// 字典值
        /// </summary>
        [Required(ErrorMessage = "Value不能为空")]
        [StringLength( 50 )]
        [Display( Name = "Value" )]
        public string Value { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Required(ErrorMessage = "Sort不能为空")]
        [Display( Name = "Sort" )]
        public int Sort { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Display( Name = "Status" )]
        public bool? Status { get; set; }
    }
}