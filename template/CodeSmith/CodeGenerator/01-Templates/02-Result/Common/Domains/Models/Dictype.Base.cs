using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Domains.Tenants;

namespace PSharp.Template.Common.Domains.Models {
    /// <summary>
    /// 字典类型
    /// </summary>
    [DisplayName( "字典类型" )]
    public partial class Dictype : AggregateRoot<Dictype>,IDelete,IAudited {
        /// <summary>
        /// 初始化字典类型
        /// </summary>
        public Dictype() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化字典类型
        /// </summary>
        /// <param name="id">字典类型标识</param>
        public Dictype( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 类型名称
        /// </summary>
        [DisplayName( "类型名称" )]
        [Required(ErrorMessage = "类型名称不能为空")]
        [StringLength( 200 )]
        public string Name { get; set; }
        /// <summary>
        /// 类型代码
        /// </summary>
        [DisplayName( "类型代码" )]
        [Required(ErrorMessage = "类型代码不能为空")]
        [StringLength( 200 )]
        public string Code { get; set; }
        /// <summary>
        /// 字典类型状态
        /// </summary>
        [DisplayName( "字典类型状态" )]
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
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.Name );
            AddDescription( t => t.Code );
            AddDescription( t => t.Status );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Dictype other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.Code, other.Code );
            AddChange( t => t.Status, other.Status );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}