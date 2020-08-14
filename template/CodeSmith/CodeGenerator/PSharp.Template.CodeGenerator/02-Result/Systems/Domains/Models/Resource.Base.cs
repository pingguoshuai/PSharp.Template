using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains;
using Util.Domains.Trees;
using Util.Domains.Auditing;
using Util.Domains.Tenants;

namespace PSharp.Template.Systems.Domain.Models {
    /// <summary>
    /// 身份资源
    /// </summary>
    [Description( "身份资源" )]
    public partial class Resource : TreeEntityBase<Resource>,IDelete,IAudited {
        /// <summary>
        /// 初始化身份资源
        /// </summary>
        public Resource()
            : this( Guid.Empty, "", 0 ) {
        }

        /// <summary>
        /// 初始化身份资源
        /// </summary>
        /// <param name="id">身份资源标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">层级</param>
        public Resource( Guid id, string path, int level )
            : base( id, path, level ) {
        }

        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage = "Name不能为空")]
        [StringLength( 800 )]
        public string Name { get; set; }
        /// <summary>
        /// RouteName
        /// </summary>
        [StringLength( 800 )]
        public string RouteName { get; set; }
        /// <summary>
        /// RouteUri
        /// </summary>
        [Required(ErrorMessage = "RouteUri不能为空")]
        [StringLength( 1200 )]
        public string RouteUri { get; set; }
        /// <summary>
        /// 资源类型
        /// </summary>
        [Required(ErrorMessage = "资源类型不能为空")]
        public int Type { get; set; }
        /// <summary>
        /// IsHide
        /// </summary>
        public bool? IsHide { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [StringLength( 200 )]
        public string Icon { get; set; }
        /// <summary>
        /// KeepAlive
        /// </summary>
        public bool? KeepAlive { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        [StringLength( 2000 )]
        public string Remark { get; set; }
        /// <summary>
        /// Required
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// CreationTime
        /// </summary>
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// CreatorId
        /// </summary>
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// LastModificationTime
        /// </summary>
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// LastModifierId
        /// </summary>
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// ApplicationId
        /// </summary>
        public Guid? ApplicationId { get; set; }
        /// <summary>
        /// 应用程序
        /// </summary>
        [ForeignKey( "Id" )]
        public Application Application { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.ParentId );
            AddDescription( t => t.Path );
            AddDescription( t => t.Level );
            AddDescription( t => t.Enabled );
            AddDescription( t => t.SortId );
            AddDescription( t => t.Name );
            AddDescription( t => t.RouteName );
            AddDescription( t => t.RouteUri );
            AddDescription( t => t.Type );
            AddDescription( t => t.IsHide );
            AddDescription( t => t.Icon );
            AddDescription( t => t.KeepAlive );
            AddDescription( t => t.Remark );
            AddDescription( t => t.Required );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
            AddDescription( t => t.ApplicationId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Resource other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.ParentId, other.ParentId );
            AddChange( t => t.Path, other.Path );
            AddChange( t => t.Level, other.Level );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.SortId, other.SortId );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.RouteName, other.RouteName );
            AddChange( t => t.RouteUri, other.RouteUri );
            AddChange( t => t.Type, other.Type );
            AddChange( t => t.IsHide, other.IsHide );
            AddChange( t => t.Icon, other.Icon );
            AddChange( t => t.KeepAlive, other.KeepAlive );
            AddChange( t => t.Remark, other.Remark );
            AddChange( t => t.Required, other.Required );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
            AddChange( t => t.ApplicationId, other.ApplicationId );
        }
    }
}