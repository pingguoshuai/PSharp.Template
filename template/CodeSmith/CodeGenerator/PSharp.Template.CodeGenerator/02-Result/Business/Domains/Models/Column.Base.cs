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
    /// 栏目
    /// </summary>
    [DisplayName( "栏目" )]
    public partial class Column : AggregateRoot<Column>,ITenant,IDelete,IAudited {
        /// <summary>
        /// 初始化栏目
        /// </summary>
        public Column() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化栏目
        /// </summary>
        /// <param name="id">栏目标识</param>
        public Column( Guid id ) : base( id ) {
        }

        /// <summary>
        /// ParentId
        /// </summary>
        [DisplayName( "ParentId" )]
        public Guid? ParentId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName( "名称" )]
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength( 200 )]
        public string Name { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [DisplayName( "图片" )]
        public Guid? IconId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName( "类型" )]
        [Required(ErrorMessage = "类型不能为空")]
        public Guid TypeId { get; set; }
        /// <summary>
        /// 自定义名称
        /// </summary>
        [DisplayName( "自定义名称" )]
        [Required(ErrorMessage = "自定义名称不能为空")]
        [StringLength( 200 )]
        public string DiyName { get; set; }
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
        /// 链接
        /// </summary>
        [DisplayName( "链接" )]
        [StringLength( 1020 )]
        public string OutLink { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName( "排序" )]
        [Required(ErrorMessage = "排序不能为空")]
        public int Sort { get; set; }
        /// <summary>
        /// 分页大小
        /// </summary>
        [DisplayName( "分页大小" )]
        [Required(ErrorMessage = "分页大小不能为空")]
        public int PageSize { get; set; }
        /// <summary>
        /// 是否可投稿
        /// </summary>
        [DisplayName( "是否可投稿" )]
        public bool IsContribute { get; set; }
        /// <summary>
        /// 导航显示
        /// </summary>
        [DisplayName( "导航显示" )]
        public bool IsNav { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [DisplayName( "状态" )]
        public bool Status { get; set; }
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
        public Column ParentColumn { get; set; }
        /// <summary>
        /// 数据字典
        /// </summary>
        public Dicinfo TypeDicinfo { get; set; }
        /// <summary>
        /// 文件
        /// </summary>
        public Sysfile IconSysfile { get; set; }
        /// <summary>
        /// 栏目
        /// </summary>
        public Column ParentColumn1 { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.ParentId );
            AddDescription( t => t.Name );
            AddDescription( t => t.IconId );
            AddDescription( t => t.TypeId );
            AddDescription( t => t.DiyName );
            AddDescription( t => t.Keywords );
            AddDescription( t => t.Descrition );
            AddDescription( t => t.OutLink );
            AddDescription( t => t.Sort );
            AddDescription( t => t.PageSize );
            AddDescription( t => t.IsContribute );
            AddDescription( t => t.IsNav );
            AddDescription( t => t.Status );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
            AddDescription( t => t.TenantId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Column other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.ParentId, other.ParentId );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.IconId, other.IconId );
            AddChange( t => t.TypeId, other.TypeId );
            AddChange( t => t.DiyName, other.DiyName );
            AddChange( t => t.Keywords, other.Keywords );
            AddChange( t => t.Descrition, other.Descrition );
            AddChange( t => t.OutLink, other.OutLink );
            AddChange( t => t.Sort, other.Sort );
            AddChange( t => t.PageSize, other.PageSize );
            AddChange( t => t.IsContribute, other.IsContribute );
            AddChange( t => t.IsNav, other.IsNav );
            AddChange( t => t.Status, other.Status );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
            AddChange( t => t.TenantId, other.TenantId );
        }
    }
}