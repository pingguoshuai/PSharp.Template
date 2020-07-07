using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using PSharp.Template.Core.Applications.Dtos;

namespace PSharp.Template.Common.Services.Dtos.Requests {
    /// <summary>
    /// 字典类型参数
    /// </summary>
    public class CreateDicTypeRequest : RequestBase {
        /// <summary>
        /// 字典类型名称
        /// </summary>
        [Required(ErrorMessage = "Name不能为空")]
        [StringLength( 50 )]
        [Display( Name = "名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 字典类型编码
        /// </summary>
        [Required(ErrorMessage = "Code不能为空")]
        [StringLength( 50 )]
        [Display( Name = "Code" )]
        public string Code { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Display( Name = "Status" )]
        public bool? Status { get; set; }
    }
}