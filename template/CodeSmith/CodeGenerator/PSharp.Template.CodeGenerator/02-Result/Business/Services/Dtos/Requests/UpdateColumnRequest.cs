using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using PSharp.Template.Core.Applications.Dtos;

namespace PSharp.Template.Business.Services.Dtos.Requests {
    /// <summary>
    /// 栏目参数
    /// </summary>
    public class UpdateColumnRequest : RequestBase {
        /// <summary>
        /// ParentId
        /// </summary>
        [Display( Name = "ParentId" )]
        public Guid? ParentId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength( 200 )]
        [Display( Name = "名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [Display( Name = "图片" )]
        public Guid? IconId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Required(ErrorMessage = "类型不能为空")]
        [Display( Name = "类型" )]
        public Guid TypeId { get; set; }
        /// <summary>
        /// 自定义名称
        /// </summary>
        [Required(ErrorMessage = "自定义名称不能为空")]
        [StringLength( 200 )]
        [Display( Name = "自定义名称" )]
        public string DiyName { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        [StringLength( 2000 )]
        [Display( Name = "关键字" )]
        public string Keywords { get; set; }
        /// <summary>
        /// 页面描述
        /// </summary>
        [StringLength( 8000 )]
        [Display( Name = "页面描述" )]
        public string Descrition { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        [StringLength( 1020 )]
        [Display( Name = "链接" )]
        public string OutLink { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Required(ErrorMessage = "排序不能为空")]
        [Display( Name = "排序" )]
        public int Sort { get; set; }
        /// <summary>
        /// 分页大小
        /// </summary>
        [Required(ErrorMessage = "分页大小不能为空")]
        [Display( Name = "分页大小" )]
        public int PageSize { get; set; }
        /// <summary>
        /// 是否可投稿
        /// </summary>
        [Display( Name = "是否可投稿" )]
        public bool? IsContribute { get; set; }
        /// <summary>
        /// 导航显示
        /// </summary>
        [Display( Name = "导航显示" )]
        public bool? IsNav { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Display( Name = "状态" )]
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
        /// <summary>
        /// TenantId
        /// </summary>
        [StringLength( 2147483647 )]
        [Display( Name = "TenantId" )]
        public string TenantId { get; set; }
    }
}