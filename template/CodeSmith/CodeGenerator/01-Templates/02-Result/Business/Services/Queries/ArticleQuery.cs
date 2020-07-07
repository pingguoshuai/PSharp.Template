using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Business.Services.Queries {
    /// <summary>
    /// 文章查询参数
    /// </summary>
    public class ArticleQuery : QueryParameter {
        /// <summary>
        /// Id
        /// </summary>
        [Display(Name="Id")]
        public Guid? Id { get; set; }
        /// <summary>
        /// 栏目ID
        /// </summary>
        [Display(Name="栏目ID")]
        public Guid? ColumnId { get; set; }
        
        private string _title = string.Empty;
        /// <summary>
        /// 标题
        /// </summary>
        [Display(Name="标题")]
        public string Title {
            get => _title == null ? string.Empty : _title.Trim();
            set => _title = value;
        }
        
        private string _style = string.Empty;
        /// <summary>
        /// 标题样式
        /// </summary>
        [Display(Name="标题样式")]
        public string Style {
            get => _style == null ? string.Empty : _style.Trim();
            set => _style = value;
        }
        
        private string _keywords = string.Empty;
        /// <summary>
        /// 关键字
        /// </summary>
        [Display(Name="关键字")]
        public string Keywords {
            get => _keywords == null ? string.Empty : _keywords.Trim();
            set => _keywords = value;
        }
        
        private string _descrition = string.Empty;
        /// <summary>
        /// 页面描述
        /// </summary>
        [Display(Name="页面描述")]
        public string Descrition {
            get => _descrition == null ? string.Empty : _descrition.Trim();
            set => _descrition = value;
        }
        
        private string _author = string.Empty;
        /// <summary>
        /// 作者
        /// </summary>
        [Display(Name="作者")]
        public string Author {
            get => _author == null ? string.Empty : _author.Trim();
            set => _author = value;
        }
        
        private string _source = string.Empty;
        /// <summary>
        /// 来源
        /// </summary>
        [Display(Name="来源")]
        public string Source {
            get => _source == null ? string.Empty : _source.Trim();
            set => _source = value;
        }
        /// <summary>
        /// 焦点关注
        /// </summary>
        [Display(Name="焦点关注")]
        public bool? IsFocus { get; set; }
        /// <summary>
        /// 热门推荐
        /// </summary>
        [Display(Name="热门推荐")]
        public bool? IsHot { get; set; }
        /// <summary>
        /// 图文特推
        /// </summary>
        [Display(Name="图文特推")]
        public bool? IsImg { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name="排序")]
        public int? Sort { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        [Display(Name="封面")]
        public Guid? CoverId { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        [Display(Name="浏览量")]
        public int? Hits { get; set; }
        /// <summary>
        /// 是否外链
        /// </summary>
        [Display(Name="是否外链")]
        public bool? IsLink { get; set; }
        
        private string _linkUrl = string.Empty;
        /// <summary>
        /// 链接地址
        /// </summary>
        [Display(Name="链接地址")]
        public string LinkUrl {
            get => _linkUrl == null ? string.Empty : _linkUrl.Trim();
            set => _linkUrl = value;
        }
        
        private string _content = string.Empty;
        /// <summary>
        /// 内容
        /// </summary>
        [Display(Name="内容")]
        public string Content {
            get => _content == null ? string.Empty : _content.Trim();
            set => _content = value;
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
        
        private string _tenantId = string.Empty;
        /// <summary>
        /// TenantId
        /// </summary>
        [Display(Name="TenantId")]
        public string TenantId {
            get => _tenantId == null ? string.Empty : _tenantId.Trim();
            set => _tenantId = value;
        }
    }
}