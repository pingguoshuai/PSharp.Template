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
    /// 文件
    /// </summary>
    [DisplayName( "文件" )]
    public partial class Sysfile : AggregateRoot<Sysfile>,IDelete,IAudited {
        /// <summary>
        /// 初始化文件
        /// </summary>
        public Sysfile() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化文件
        /// </summary>
        /// <param name="id">文件标识</param>
        public Sysfile( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 原名称
        /// </summary>
        [DisplayName( "原名称" )]
        [Required(ErrorMessage = "原名称不能为空")]
        [StringLength( 1200 )]
        public string OldName { get; set; }
        /// <summary>
        /// 新名称
        /// </summary>
        [DisplayName( "新名称" )]
        [Required(ErrorMessage = "新名称不能为空")]
        [StringLength( 1200 )]
        public string NewName { get; set; }
        /// <summary>
        /// 扩展名
        /// </summary>
        [DisplayName( "扩展名" )]
        [Required(ErrorMessage = "扩展名不能为空")]
        [StringLength( 40 )]
        public string Extension { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        [DisplayName( "大小" )]
        [Required(ErrorMessage = "大小不能为空")]
        public int Size { get; set; }
        /// <summary>
        /// Md5
        /// </summary>
        [DisplayName( "Md5" )]
        [Required(ErrorMessage = "Md5不能为空")]
        [StringLength( 256 )]
        public string Md5 { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        [DisplayName( "路径" )]
        [Required(ErrorMessage = "路径不能为空")]
        [StringLength( 1020 )]
        public string Src { get; set; }
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
            AddDescription( t => t.OldName );
            AddDescription( t => t.NewName );
            AddDescription( t => t.Extension );
            AddDescription( t => t.Size );
            AddDescription( t => t.Md5 );
            AddDescription( t => t.Src );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Sysfile other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.OldName, other.OldName );
            AddChange( t => t.NewName, other.NewName );
            AddChange( t => t.Extension, other.Extension );
            AddChange( t => t.Size, other.Size );
            AddChange( t => t.Md5, other.Md5 );
            AddChange( t => t.Src, other.Src );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}