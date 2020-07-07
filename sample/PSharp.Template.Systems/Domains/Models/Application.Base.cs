using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PSharp.Template.Systems.Domains.Enums;
using Util.Domains;
using Util.Domains.Auditing;

namespace PSharp.Template.Systems.Domains.Models
{
    [Table("Systems.Application")]
    [Description("应用程序")]
    public partial class Application : AggregateRoot<Application>, IAudited
    {
        /// <summary>
        /// 初始化应用程序
        /// </summary>
        public Application() : this(Guid.Empty)
        {
        }

        /// <summary>
        /// 初始化应用程序
        /// </summary>
        /// <param name="id">应用程序标识</param>
        public Application(Guid id) : base(id)
        {

        }

        /// <summary>
        /// 应用程序编码
        /// </summary>
        [DisplayName("应用程序编码")]
        [Required(ErrorMessage = "应用程序编码不能为空")]
        [StringLength(60)]
        public string Code { get; set; }

        /// <summary>
        /// 应用程序名称
        /// </summary>
        [DisplayName("应用程序名称")]
        [Required(ErrorMessage = "应用程序名称不能为空")]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [DisplayName("启用")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 启用注册
        /// </summary>
        [DisplayName("启用注册")]
        public bool RegisterEnabled { get; set; }

        /// <summary>
        /// 扩展
        /// </summary>  
        [DisplayName("扩展")]
        public string Extend { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        [StringLength(500)]
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// 创建人标识
        /// </summary>
        [DisplayName("创建人标识")]
        public Guid? CreatorId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 最后修改人标识
        /// </summary>
        [DisplayName("最后修改人标识")]
        public Guid? LastModifierId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [DisplayName("是否删除")]
        public bool IsDeleted { get; set; }
    }
}
