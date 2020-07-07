using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;

namespace PSharp.Template.Systems.Services.Dtos {
    /// <summary>
    /// 应用程序参数
    /// </summary>
    public class ApplicationDto : DtoBase {
        /// <summary>
        /// Version
        /// </summary>
        [Display( Name = "Version" )]
        public Byte[] Version { get; set; }
        /// <summary>
        /// 应用程序编码
        /// </summary>
        [Required(ErrorMessage = "应用程序编码不能为空")]
        [StringLength( 240 )]
        [Display( Name = "应用程序编码" )]
        public string Code { get; set; }
        /// <summary>
        /// 应用程序名称
        /// </summary>
        [Required(ErrorMessage = "应用程序名称不能为空")]
        [StringLength( 800 )]
        [Display( Name = "应用程序名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Display( Name = "启用" )]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 启用注册
        /// </summary>
        [Display( Name = "启用注册" )]
        public bool? RegisterEnabled { get; set; }
        /// <summary>
        /// 扩展
        /// </summary>
        [StringLength( 2147483647 )]
        [Display( Name = "扩展" )]
        public string Extend { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 2000 )]
        [Display( Name = "备注" )]
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display( Name = "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        /// </summary>
        [Display( Name = "创建人标识" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Display( Name = "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        /// </summary>
        [Display( Name = "最后修改人标识" )]
        public Guid? LastModifierId { get; set; }
    }
}