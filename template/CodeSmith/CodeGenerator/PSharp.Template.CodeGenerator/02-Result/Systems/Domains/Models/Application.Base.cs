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
    /// 应用程序
    /// </summary>
    [DisplayName( "应用程序" )]
    public partial class Application : AggregateRoot<Application>,IDelete,IAudited {
        /// <summary>
        /// 初始化应用程序
        /// </summary>
        public Application() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化应用程序
        /// </summary>
        /// <param name="id">应用程序标识</param>
        public Application( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 应用程序编码
        /// </summary>
        [DisplayName( "应用程序编码" )]
        [Required(ErrorMessage = "应用程序编码不能为空")]
        [StringLength( 240 )]
        public string Code { get; set; }
        /// <summary>
        /// 应用程序名称
        /// </summary>
        [DisplayName( "应用程序名称" )]
        [Required(ErrorMessage = "应用程序名称不能为空")]
        [StringLength( 800 )]
        public string Name { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [DisplayName( "启用" )]
        public bool Enabled { get; set; }
        /// <summary>
        /// 启用注册
        /// </summary>
        [DisplayName( "启用注册" )]
        public bool RegisterEnabled { get; set; }
        /// <summary>
        /// 扩展
        /// </summary>
        [DisplayName( "扩展" )]
        [StringLength( 2147483647 )]
        public string Extend { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName( "备注" )]
        [StringLength( 2000 )]
        public string Remark { get; set; }
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
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.Code );
            AddDescription( t => t.Name );
            AddDescription( t => t.Enabled );
            AddDescription( t => t.RegisterEnabled );
            AddDescription( t => t.Extend );
            AddDescription( t => t.Remark );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Application other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.Code, other.Code );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.RegisterEnabled, other.RegisterEnabled );
            AddChange( t => t.Extend, other.Extend );
            AddChange( t => t.Remark, other.Remark );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}