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
    /// 角色
    /// </summary>
    [Description( "角色" )]
    public partial class Role : TreeEntityBase<Role>,IDelete,IAudited {
        /// <summary>
        /// 初始化角色
        /// </summary>
        public Role()
            : this( Guid.Empty, "", 0 ) {
        }

        /// <summary>
        /// 初始化角色
        /// </summary>
        /// <param name="id">角色标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">层级</param>
        public Role( Guid id, string path, int level )
            : base( id, path, level ) {
        }

        /// <summary>
        /// Code
        /// </summary>
        [Required(ErrorMessage = "Code不能为空")]
        [StringLength( 1024 )]
        public string Code { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "角色名称不能为空")]
        [StringLength( 1024 )]
        public string Name { get; set; }
        /// <summary>
        /// NormalizedName
        /// </summary>
        [Required(ErrorMessage = "NormalizedName不能为空")]
        [StringLength( 1024 )]
        public string NormalizedName { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        [Required(ErrorMessage = "Type不能为空")]
        [StringLength( 320 )]
        public string Type { get; set; }
        /// <summary>
        /// IsAdmin
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        [StringLength( 2000 )]
        public string Remark { get; set; }
        /// <summary>
        /// PinYin
        /// </summary>
        [StringLength( 800 )]
        public string PinYin { get; set; }
        /// <summary>
        /// Sign
        /// </summary>
        [StringLength( 1024 )]
        public string Sign { get; set; }
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
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.ParentId );
            AddDescription( t => t.Path );
            AddDescription( t => t.Level );
            AddDescription( t => t.Enabled );
            AddDescription( t => t.SortId );
            AddDescription( t => t.Code );
            AddDescription( t => t.Name );
            AddDescription( t => t.NormalizedName );
            AddDescription( t => t.Type );
            AddDescription( t => t.IsAdmin );
            AddDescription( t => t.Remark );
            AddDescription( t => t.PinYin );
            AddDescription( t => t.Sign );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Role other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.ParentId, other.ParentId );
            AddChange( t => t.Path, other.Path );
            AddChange( t => t.Level, other.Level );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.SortId, other.SortId );
            AddChange( t => t.Code, other.Code );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.NormalizedName, other.NormalizedName );
            AddChange( t => t.Type, other.Type );
            AddChange( t => t.IsAdmin, other.IsAdmin );
            AddChange( t => t.Remark, other.Remark );
            AddChange( t => t.PinYin, other.PinYin );
            AddChange( t => t.Sign, other.Sign );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}