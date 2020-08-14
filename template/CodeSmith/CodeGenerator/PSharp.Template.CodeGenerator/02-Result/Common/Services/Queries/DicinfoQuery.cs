using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Common.Services.Queries {
    /// <summary>
    /// 数据字典查询参数
    /// </summary>
    public class DicinfoQuery : QueryParameter {
        /// <summary>
        /// Id
        /// </summary>
        [Display(Name="Id")]
        public Guid? Id { get; set; }
        /// <summary>
        /// DicTypeId
        /// </summary>
        [Display(Name="DicTypeId")]
        public Guid? DicTypeId { get; set; }
        
        private string _name = string.Empty;
        /// <summary>
        /// 字典名称
        /// </summary>
        [Display(Name="字典名称")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        
        private string _value = string.Empty;
        /// <summary>
        /// 字典值
        /// </summary>
        [Display(Name="字典值")]
        public string Value {
            get => _value == null ? string.Empty : _value.Trim();
            set => _value = value;
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name="排序")]
        public int? Sort { get; set; }
        /// <summary>
        /// 字典类型状态
        /// </summary>
        [Display(Name="字典类型状态")]
        public bool? Status { get; set; }
        /// <summary>
        /// 起始CreationTime
        /// </summary>
        [Display( Name = "起始CreationTime" )]
        public DateTime? BeginCreationTime { get; set; }
        /// <summary>
        /// 结束CreationTime
        /// </summary>
        [Display( Name = "结束CreationTime" )]
        public DateTime? EndCreationTime { get; set; }
        /// <summary>
        /// CreatorId
        /// </summary>
        [Display(Name="CreatorId")]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 起始LastModificationTime
        /// </summary>
        [Display( Name = "起始LastModificationTime" )]
        public DateTime? BeginLastModificationTime { get; set; }
        /// <summary>
        /// 结束LastModificationTime
        /// </summary>
        [Display( Name = "结束LastModificationTime" )]
        public DateTime? EndLastModificationTime { get; set; }
        /// <summary>
        /// LastModifierId
        /// </summary>
        [Display(Name="LastModifierId")]
        public Guid? LastModifierId { get; set; }
    }
}