using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using PSharp.Template.Core.Applications.Dtos;

namespace PSharp.Template.Business.Services.Dtos.Requests {
    /// <summary>
    /// 文章参数
    /// </summary>
    public class UpdateArticleRequest : RequestBase {
        /// <summary>
        /// 栏目ID
        /// </summary>
        [Required(ErrorMessage = "栏目ID不能为空")]
        [Display( Name = "栏目ID" )]
        public Guid ColumnId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "标题不能为空")]
        [StringLength( 800 )]
        [Display( Name = "标题" )]
        public string Title { get; set; }
        /// <summary>
        /// 标题样式
        /// </summary>
        [StringLength( 320 )]
        [Display( Name = "标题样式" )]
        public string Style { get; set; }
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
        /// 作者
        /// </summary>
        [StringLength( 80 )]
        [Display( Name = "作者" )]
        public string Author { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        [StringLength( 800 )]
        [Display( Name = "来源" )]
        public string Source { get; set; }
        /// <summary>
        /// 焦点关注
        /// </summary>
        [Display( Name = "焦点关注" )]
        public bool? IsFocus { get; set; }
        /// <summary>
        /// 热门推荐
        /// </summary>
        [Display( Name = "热门推荐" )]
        public bool? IsHot { get; set; }
        /// <summary>
        /// 图文特推
        /// </summary>
        [Display( Name = "图文特推" )]
        public bool? IsImg { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Required(ErrorMessage = "排序不能为空")]
        [Display( Name = "排序" )]
        public int Sort { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        [Display( Name = "封面" )]
        public Guid? CoverId { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        [Required(ErrorMessage = "浏览量不能为空")]
        [Display( Name = "浏览量" )]
        public int Hits { get; set; }
        /// <summary>
        /// 是否外链
        /// </summary>
        [Display( Name = "是否外链" )]
        public bool? IsLink { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        [StringLength( 800 )]
        [Display( Name = "链接地址" )]
        public string LinkUrl { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [StringLength( 2147483647 )]
        [Display( Name = "内容" )]
        public string Content { get; set; }
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