using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Domains.Tenants;

namespace PSharp.Template.Business.Domains.Models {
    /// <summary>
    /// 文章
    /// </summary>
    [DisplayName( "文章" )]
    public partial class Article : AggregateRoot<Article>,ITenant,IDelete,IAudited {
        /// <summary>
        /// 初始化文章
        /// </summary>
        public Article() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化文章
        /// </summary>
        /// <param name="id">文章标识</param>
        public Article( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 栏目ID
        /// </summary>
        [DisplayName( "栏目ID" )]
        [Required(ErrorMessage = "栏目ID不能为空")]
        public Guid ColumnId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName( "标题" )]
        [Required(ErrorMessage = "标题不能为空")]
        [StringLength( 800 )]
        public string Title { get; set; }
        /// <summary>
        /// 标题样式
        /// </summary>
        [DisplayName( "标题样式" )]
        [StringLength( 320 )]
        public string Style { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        [DisplayName( "关键字" )]
        [StringLength( 2000 )]
        public string Keywords { get; set; }
        /// <summary>
        /// 页面描述
        /// </summary>
        [DisplayName( "页面描述" )]
        [StringLength( 8000 )]
        public string Descrition { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [DisplayName( "作者" )]
        [StringLength( 80 )]
        public string Author { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        [DisplayName( "来源" )]
        [StringLength( 800 )]
        public string Source { get; set; }
        /// <summary>
        /// 焦点关注
        /// </summary>
        [DisplayName( "焦点关注" )]
        public bool IsFocus { get; set; }
        /// <summary>
        /// 热门推荐
        /// </summary>
        [DisplayName( "热门推荐" )]
        public bool IsHot { get; set; }
        /// <summary>
        /// 图文特推
        /// </summary>
        [DisplayName( "图文特推" )]
        public bool IsImg { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName( "排序" )]
        [Required(ErrorMessage = "排序不能为空")]
        public int Sort { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        [DisplayName( "封面" )]
        public Guid? CoverId { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        [DisplayName( "浏览量" )]
        [Required(ErrorMessage = "浏览量不能为空")]
        public int Hits { get; set; }
        /// <summary>
        /// 是否外链
        /// </summary>
        [DisplayName( "是否外链" )]
        public bool IsLink { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        [DisplayName( "链接地址" )]
        [StringLength( 800 )]
        public string LinkUrl { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [DisplayName( "内容" )]
        [StringLength( 2147483647 )]
        public string Content { get; set; }
        /// <summary>
        /// CreationTime
        /// </summary>
        [DisplayName( "CreationTime" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// CreatorId
        /// </summary>
        [DisplayName( "CreatorId" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// LastModificationTime
        /// </summary>
        [DisplayName( "LastModificationTime" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// LastModifierId
        /// </summary>
        [DisplayName( "LastModifierId" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [DisplayName( "是否删除" )]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// TenantId
        /// </summary>
        [DisplayName( "TenantId" )]
        [StringLength( 2147483647 )]
        public string TenantId { get; set; }
        /// <summary>
        /// 栏目
        /// </summary>
        public Column Column { get; set; }
        /// <summary>
        /// 文件
        /// </summary>
        public Sysfile CoverSysfile { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.ColumnId );
            AddDescription( t => t.Title );
            AddDescription( t => t.Style );
            AddDescription( t => t.Keywords );
            AddDescription( t => t.Descrition );
            AddDescription( t => t.Author );
            AddDescription( t => t.Source );
            AddDescription( t => t.IsFocus );
            AddDescription( t => t.IsHot );
            AddDescription( t => t.IsImg );
            AddDescription( t => t.Sort );
            AddDescription( t => t.CoverId );
            AddDescription( t => t.Hits );
            AddDescription( t => t.IsLink );
            AddDescription( t => t.LinkUrl );
            AddDescription( t => t.Content );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
            AddDescription( t => t.TenantId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Article other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.ColumnId, other.ColumnId );
            AddChange( t => t.Title, other.Title );
            AddChange( t => t.Style, other.Style );
            AddChange( t => t.Keywords, other.Keywords );
            AddChange( t => t.Descrition, other.Descrition );
            AddChange( t => t.Author, other.Author );
            AddChange( t => t.Source, other.Source );
            AddChange( t => t.IsFocus, other.IsFocus );
            AddChange( t => t.IsHot, other.IsHot );
            AddChange( t => t.IsImg, other.IsImg );
            AddChange( t => t.Sort, other.Sort );
            AddChange( t => t.CoverId, other.CoverId );
            AddChange( t => t.Hits, other.Hits );
            AddChange( t => t.IsLink, other.IsLink );
            AddChange( t => t.LinkUrl, other.LinkUrl );
            AddChange( t => t.Content, other.Content );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
            AddChange( t => t.TenantId, other.TenantId );
        }
    }
}