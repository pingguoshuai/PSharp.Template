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
    public class UpdateDictypeRequest : RequestBase {
        /// <summary>
        /// 类型名称
        /// </summary>
        [Required(ErrorMessage = "类型名称不能为空")]
        [StringLength( 200 )]
        [Display( Name = "类型名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 类型代码
        /// </summary>
        [Required(ErrorMessage = "类型代码不能为空")]
        [StringLength( 200 )]
        [Display( Name = "类型代码" )]
        public string Code { get; set; }
        /// <summary>
        /// 字典类型状态
        /// </summary>
        [Display( Name = "字典类型状态" )]
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
    }
}