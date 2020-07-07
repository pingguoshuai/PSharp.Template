using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Systems.Services.Queries {
    /// <summary>
    /// 查询参数
    /// </summary>
    public class ApplicationQuery : QueryParameter {
        /// <summary>
        /// Id
        /// </summary>
        [Display(Name="Id")]
        public Guid? Id { get; set; }
        
        private string _code = string.Empty;
        /// <summary>
        /// Code
        /// </summary>
        [Display(Name="Code")]
        public string Code {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }
        
        private string _name = string.Empty;
        /// <summary>
        /// Name
        /// </summary>
        [Display(Name="Name")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        /// <summary>
        /// Enabled
        /// </summary>
        [Display(Name="Enabled")]
        public bool? Enabled { get; set; }
        /// <summary>
        /// RegisterEnabled
        /// </summary>
        [Display(Name="RegisterEnabled")]
        public bool? RegisterEnabled { get; set; }
        
        private string _remark = string.Empty;
        /// <summary>
        /// Remark
        /// </summary>
        [Display(Name="Remark")]
        public string Remark {
            get => _remark == null ? string.Empty : _remark.Trim();
            set => _remark = value;
        }
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
        /// <summary>
        /// ApplicationType
        /// </summary>
        [Display(Name="ApplicationType")]
        public int? ApplicationType { get; set; }
        /// <summary>
        /// IsClient
        /// </summary>
        [Display(Name="IsClient")]
        public bool? IsClient { get; set; }
    }
}