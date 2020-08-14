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
    /// 角色接口
    /// </summary>
    [DisplayName( "角色接口" )]
    public partial class Roleinterface : AggregateRoot<Roleinterface> {
        /// <summary>
        /// 初始化角色接口
        /// </summary>
        public Roleinterface() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化角色接口
        /// </summary>
        /// <param name="id">角色接口标识</param>
        public Roleinterface( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 角色标识
        /// </summary>
        [DisplayName( "角色标识" )]
        [Required(ErrorMessage = "角色标识不能为空")]
        public Guid RoleId { get; set; }
        /// <summary>
        /// 接口标识
        /// </summary>
        [DisplayName( "接口标识" )]
        [StringLength( 2147483647 )]
        public string InterfaceCode { get; set; }
        /// <summary>
        /// 应用程序标识
        /// </summary>
        [DisplayName( "应用程序标识" )]
        [Required(ErrorMessage = "应用程序标识不能为空")]
        public Guid ApplicationId { get; set; }
        /// <summary>
        /// 应用程序
        /// </summary>
        public Application Application { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public Role Role { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.RoleId );
            AddDescription( t => t.InterfaceCode );
            AddDescription( t => t.ApplicationId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Roleinterface other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.RoleId, other.RoleId );
            AddChange( t => t.InterfaceCode, other.InterfaceCode );
            AddChange( t => t.ApplicationId, other.ApplicationId );
        }
    }
}