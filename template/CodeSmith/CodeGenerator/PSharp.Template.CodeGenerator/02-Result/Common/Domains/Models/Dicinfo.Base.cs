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
    /// 数据字典
    /// </summary>
    [DisplayName( "数据字典" )]
    public partial class Dicinfo : AggregateRoot<Dicinfo>,IDelete,IAudited {
        /// <summary>
        /// 初始化数据字典
        /// </summary>
        public Dicinfo() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化数据字典
        /// </summary>
        /// <param name="id">数据字典标识</param>
        public Dicinfo( Guid id ) : base( id ) {
        }

        /// <summary>
        /// DicTypeId
        /// </summary>
        [DisplayName( "DicTypeId" )]
        [Required(ErrorMessage = "DicTypeId不能为空")]
        public Guid DicTypeId { get; set; }
        /// <summary>
        /// 字典名称
        /// </summary>
        [DisplayName( "字典名称" )]
        [Required(ErrorMessage = "字典名称不能为空")]
        [StringLength( 200 )]
        public string Name { get; set; }
        /// <summary>
        /// 字典值
        /// </summary>
        [DisplayName( "字典值" )]
        [Required(ErrorMessage = "字典值不能为空")]
        [StringLength( 200 )]
        public string Value { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName( "排序" )]
        [Required(ErrorMessage = "排序不能为空")]
        public int Sort { get; set; }
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
        /// 字典类型
        /// </summary>
        public Dictype Dictype { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.DicTypeId );
            AddDescription( t => t.Name );
            AddDescription( t => t.Value );
            AddDescription( t => t.Sort );
            AddDescription( t => t.Status );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Dicinfo other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.DicTypeId, other.DicTypeId );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.Value, other.Value );
            AddChange( t => t.Sort, other.Sort );
            AddChange( t => t.Status, other.Status );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}