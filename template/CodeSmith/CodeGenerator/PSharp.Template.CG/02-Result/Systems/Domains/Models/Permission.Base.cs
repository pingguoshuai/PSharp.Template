using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Domains.Tenants;

namespace PSharp.Template.Systems.Domains.Models {
    /// <summary>
    /// 权限
    /// </summary>
    [DisplayName( "权限" )]
    public partial class Permission : AggregateRoot<Permission>,IDelete,IAudited {
        /// <summary>
        /// 初始化权限
        /// </summary>
        public Permission() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化权限
        /// </summary>
        /// <param name="id">权限标识</param>
        public Permission( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 角色标识
        /// </summary>
        [DisplayName( "角色标识" )]
        [Required(ErrorMessage = "角色标识不能为空")]
        public Guid RoleId { get; set; }
        /// <summary>
        /// 资源标识
        /// </summary>
        [DisplayName( "资源标识" )]
        [Required(ErrorMessage = "资源标识不能为空")]
        public Guid ResourceId { get; set; }
        /// <summary>
        /// 拒绝
        /// </summary>
        [DisplayName( "拒绝" )]
        public bool IsDeny { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        [DisplayName( "签名" )]
        [StringLength( 1024 )]
        public string Sign { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName( "创建时间" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        /// </summary>
        [DisplayName( "创建人标识" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DisplayName( "最后修改时间" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        /// </summary>
        [DisplayName( "最后修改人标识" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [DisplayName( "是否删除" )]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 身份资源
        /// </summary>
        public Resource Resource { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.RoleId );
            AddDescription( t => t.ResourceId );
            AddDescription( t => t.IsDeny );
            AddDescription( t => t.Sign );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Permission other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.RoleId, other.RoleId );
            AddChange( t => t.ResourceId, other.ResourceId );
            AddChange( t => t.IsDeny, other.IsDeny );
            AddChange( t => t.Sign, other.Sign );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}