using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Common.Services.Queries {
    /// <summary>
    /// 字典类型查询参数
    /// </summary>
    public class DictypeQuery : QueryParameter {
        /// <summary>
        /// Id
        /// </summary>
        [Display(Name="Id")]
        public Guid? Id { get; set; }
        
        private string _name = string.Empty;
        /// <summary>
        /// 类型名称
        /// </summary>
        [Display(Name="类型名称")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        
        private string _code = string.Empty;
        /// <summary>
        /// 类型代码
        /// </summary>
        [Display(Name="类型代码")]
        public string Code {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }
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