﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Domains.Tenants;

namespace PSharp.Template.Systems.Domains.Models {
    /// <summary>
    /// 管理员
    /// </summary>
    [DisplayName( "管理员" )]
    public partial class User : AggregateRoot<User>,IDelete,IAudited {
        /// <summary>
        /// 初始化管理员
        /// </summary>
        public User() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化管理员
        /// </summary>
        /// <param name="id">管理员标识</param>
        public User( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName( "用户名" )]
        [StringLength( 1024 )]
        public string UserName { get; set; }
        /// <summary>
        /// 标准化用户名
        /// </summary>
        [DisplayName( "标准化用户名" )]
        [StringLength( 1024 )]
        public string NormalizedUserName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [DisplayName( "昵称" )]
        [StringLength( 1024 )]
        public string NickName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName( "姓名" )]
        [StringLength( 1024 )]
        public string Name { get; set; }
        /// <summary>
        /// 安全邮箱
        /// </summary>
        [DisplayName( "安全邮箱" )]
        [StringLength( 1024 )]
        public string Email { get; set; }
        /// <summary>
        /// 标准化邮箱
        /// </summary>
        [DisplayName( "标准化邮箱" )]
        [StringLength( 1024 )]
        public string NormalizedEmail { get; set; }
        /// <summary>
        /// 邮箱已确认
        /// </summary>
        [DisplayName( "邮箱已确认" )]
        public bool EmailConfirmed { get; set; }
        /// <summary>
        /// 安全手机
        /// </summary>
        [DisplayName( "安全手机" )]
        [StringLength( 256 )]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 手机已确认
        /// </summary>
        [DisplayName( "手机已确认" )]
        public bool PhoneNumberConfirmed { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName( "密码" )]
        [StringLength( 1024 )]
        public string Password { get; set; }
        /// <summary>
        /// 密码散列
        /// </summary>
        [DisplayName( "密码散列" )]
        [StringLength( 4096 )]
        public string PasswordHash { get; set; }
        /// <summary>
        /// 安全码
        /// </summary>
        [DisplayName( "安全码" )]
        [StringLength( 1024 )]
        public string SafePassword { get; set; }
        /// <summary>
        /// 安全码散列
        /// </summary>
        [DisplayName( "安全码散列" )]
        [StringLength( 4096 )]
        public string SafePasswordHash { get; set; }
        /// <summary>
        /// 启用锁定
        /// </summary>
        [DisplayName( "启用锁定" )]
        public bool LockoutEnabled { get; set; }
        /// <summary>
        /// 锁定截止
        /// </summary>
        [DisplayName( "锁定截止" )]
        public DateTime? LockoutEnd { get; set; }
        /// <summary>
        /// 上次登陆时间
        /// </summary>
        [DisplayName( "上次登陆时间" )]
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 上次登陆Ip
        /// </summary>
        [DisplayName( "上次登陆Ip" )]
        [StringLength( 120 )]
        public string LastLoginIp { get; set; }
        /// <summary>
        /// 本次登陆时间
        /// </summary>
        [DisplayName( "本次登陆时间" )]
        public DateTime? CurrentLoginTime { get; set; }
        /// <summary>
        /// 本次登陆Ip
        /// </summary>
        [DisplayName( "本次登陆Ip" )]
        [StringLength( 120 )]
        public string CurrentLoginIp { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        [DisplayName( "登陆次数" )]
        public int? LoginCount { get; set; }
        /// <summary>
        /// 登陆失败次数
        /// </summary>
        [DisplayName( "登陆失败次数" )]
        public int? AccessFailedCount { get; set; }
        /// <summary>
        /// 启用两阶段认证
        /// </summary>
        [DisplayName( "启用两阶段认证" )]
        public bool TwoFactorEnabled { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [DisplayName( "启用" )]
        public bool Enabled { get; set; }
        /// <summary>
        /// 冻结时间
        /// </summary>
        [DisplayName( "冻结时间" )]
        public DateTime? DisabledTime { get; set; }
        /// <summary>
        /// 注册Ip
        /// </summary>
        [DisplayName( "注册Ip" )]
        [StringLength( 120 )]
        public string RegisterIp { get; set; }
        /// <summary>
        /// 安全戳
        /// </summary>
        [DisplayName( "安全戳" )]
        [StringLength( 4096 )]
        public string SecurityStamp { get; set; }
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
            AddDescription( t => t.UserName );
            AddDescription( t => t.NormalizedUserName );
            AddDescription( t => t.NickName );
            AddDescription( t => t.Name );
            AddDescription( t => t.Email );
            AddDescription( t => t.NormalizedEmail );
            AddDescription( t => t.EmailConfirmed );
            AddDescription( t => t.PhoneNumber );
            AddDescription( t => t.PhoneNumberConfirmed );
            AddDescription( t => t.Password );
            AddDescription( t => t.PasswordHash );
            AddDescription( t => t.SafePassword );
            AddDescription( t => t.SafePasswordHash );
            AddDescription( t => t.LockoutEnabled );
            AddDescription( t => t.LockoutEnd );
            AddDescription( t => t.LastLoginTime );
            AddDescription( t => t.LastLoginIp );
            AddDescription( t => t.CurrentLoginTime );
            AddDescription( t => t.CurrentLoginIp );
            AddDescription( t => t.LoginCount );
            AddDescription( t => t.AccessFailedCount );
            AddDescription( t => t.TwoFactorEnabled );
            AddDescription( t => t.Enabled );
            AddDescription( t => t.DisabledTime );
            AddDescription( t => t.RegisterIp );
            AddDescription( t => t.SecurityStamp );
            AddDescription( t => t.Remark );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( User other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.UserName, other.UserName );
            AddChange( t => t.NormalizedUserName, other.NormalizedUserName );
            AddChange( t => t.NickName, other.NickName );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.Email, other.Email );
            AddChange( t => t.NormalizedEmail, other.NormalizedEmail );
            AddChange( t => t.EmailConfirmed, other.EmailConfirmed );
            AddChange( t => t.PhoneNumber, other.PhoneNumber );
            AddChange( t => t.PhoneNumberConfirmed, other.PhoneNumberConfirmed );
            AddChange( t => t.Password, other.Password );
            AddChange( t => t.PasswordHash, other.PasswordHash );
            AddChange( t => t.SafePassword, other.SafePassword );
            AddChange( t => t.SafePasswordHash, other.SafePasswordHash );
            AddChange( t => t.LockoutEnabled, other.LockoutEnabled );
            AddChange( t => t.LockoutEnd, other.LockoutEnd );
            AddChange( t => t.LastLoginTime, other.LastLoginTime );
            AddChange( t => t.LastLoginIp, other.LastLoginIp );
            AddChange( t => t.CurrentLoginTime, other.CurrentLoginTime );
            AddChange( t => t.CurrentLoginIp, other.CurrentLoginIp );
            AddChange( t => t.LoginCount, other.LoginCount );
            AddChange( t => t.AccessFailedCount, other.AccessFailedCount );
            AddChange( t => t.TwoFactorEnabled, other.TwoFactorEnabled );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.DisabledTime, other.DisabledTime );
            AddChange( t => t.RegisterIp, other.RegisterIp );
            AddChange( t => t.SecurityStamp, other.SecurityStamp );
            AddChange( t => t.Remark, other.Remark );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}