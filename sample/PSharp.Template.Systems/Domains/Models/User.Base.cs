using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Util.Domains;
using Util.Domains.Auditing;

namespace PSharp.Template.Systems.Domains.Models
{
    [Table("Systems.User")]
    [Description("管理员")]
    public partial class User : AggregateRoot<User>, ICreationAudited, IModificationAudited, IDelete
    {
        public User() : base(Guid.Empty)
        {
        }

        public User(Guid id) : base(id)
        {
        }

        /// <summary>
        /// 用户名
        /// </summary>
        [DisplayName("用户名")]
        [StringLength(256)]
        public string UserName { get; set; }
        /// <summary>
        /// 标准化用户名
        /// </summary>
        [DisplayName("标准化用户名")]
        [StringLength(256)]
        public string NormalizedUserName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [DisplayName("昵称")]
        [StringLength(256)]
        public string NickName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        [StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// 安全邮箱
        /// </summary>
        [DisplayName("安全邮箱")]
        [StringLength(256)]
        public string Email { get; set; }
        /// <summary>
        /// 标准化邮箱
        /// </summary>
        [DisplayName("标准化邮箱")]
        [StringLength(256)]
        public string NormalizedEmail { get; set; }
        /// <summary>
        /// 邮箱已确认
        /// </summary>
        [DisplayName("邮箱已确认")]
        public bool EmailConfirmed { get; set; }
        /// <summary>
        /// 安全手机
        /// </summary>
        [DisplayName("安全手机")]
        [StringLength(64)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 手机已确认
        /// </summary>
        [DisplayName("手机已确认")]
        public bool PhoneNumberConfirmed { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        [StringLength(256)]
        public string Password { get; set; }
        /// <summary>
        /// 密码散列
        /// </summary>
        [DisplayName("密码散列")]
        [StringLength(1024)]
        public string PasswordHash { get; set; }
        /// <summary>
        /// 安全码
        /// </summary>
        [DisplayName("安全码")]
        [StringLength(256)]
        public string SafePassword { get; set; }
        /// <summary>
        /// 安全码散列
        /// </summary>
        [DisplayName("安全码散列")]
        [StringLength(1024)]
        public string SafePasswordHash { get; set; }
        /// <summary>
        /// 启用锁定
        /// </summary>
        [DisplayName("启用锁定")]
        public bool LockoutEnabled { get; set; }
        /// <summary>
        /// 锁定截止
        /// </summary>
        [DisplayName("锁定截止")]
        public DateTimeOffset? LockoutEnd { get; set; }
        /// <summary>
        /// 上次登陆时间
        /// </summary>
        [DisplayName("上次登陆时间")]
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 上次登陆Ip
        /// </summary>
        [DisplayName("上次登陆Ip")]
        [StringLength(30)]
        public string LastLoginIp { get; set; }
        /// <summary>
        /// 本次登陆时间
        /// </summary>
        [DisplayName("本次登陆时间")]
        public DateTime? CurrentLoginTime { get; set; }
        /// <summary>
        /// 本次登陆Ip
        /// </summary>
        [DisplayName("本次登陆Ip")]
        [StringLength(30)]
        public string CurrentLoginIp { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        [DisplayName("登陆次数")]
        public int? LoginCount { get; set; }
        /// <summary>
        /// 登陆失败次数
        /// </summary>
        [DisplayName("登陆失败次数")]
        public int? AccessFailedCount { get; set; }
        /// <summary>
        /// 启用两阶段认证
        /// </summary>
        [DisplayName("启用两阶段认证")]
        public bool TwoFactorEnabled { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [DisplayName("启用")]
        public bool Enabled { get; set; }
        /// <summary>
        /// 冻结时间
        /// </summary>
        [DisplayName("冻结时间")]
        public DateTime? DisabledTime { get; set; }
        /// <summary>
        /// 注册Ip
        /// </summary>
        [DisplayName("注册Ip")]
        [StringLength(30)]
        public string RegisterIp { get; set; }
        /// <summary>
        /// 安全戳
        /// </summary>
        [DisplayName("安全戳")]
        [StringLength(1024)]
        public string SecurityStamp { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        [StringLength(500)]
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        /// </summary>
        [DisplayName("创建人标识")]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        /// </summary>
        [DisplayName("最后修改人标识")]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [DisplayName("是否删除")]
        public bool IsDeleted { get; set; }
    }
}
