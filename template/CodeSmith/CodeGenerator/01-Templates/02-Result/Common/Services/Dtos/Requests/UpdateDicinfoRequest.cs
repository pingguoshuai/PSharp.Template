using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using PSharp.Template.Core.Applications.Dtos;

namespace PSharp.Template.Common.Services.Dtos.Requests {
    /// <summary>
    /// 数据字典参数
    /// </summary>
    public class UpdateDicinfoRequest : RequestBase {
        /// <summary>
        /// DicTypeId
        /// </summary>
        [Required(ErrorMessage = "DicTypeId不能为空")]
        [Display( Name = "DicTypeId" )]
        public Guid DicTypeId { get; set; }
        /// <summary>
        /// 字典名称
        /// </summary>
        [Required(ErrorMessage = "字典名称不能为空")]
        [StringLength( 200 )]
        [Display( Name = "字典名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 字典值
        /// </summary>
        [Required(ErrorMessage = "字典值不能为空")]
        [StringLength( 200 )]
        [Display( Name = "字典值" )]
        public string Value { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Required(ErrorMessage = "排序不能为空")]
        [Display( Name = "排序" )]
        public int Sort { get; set; }
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