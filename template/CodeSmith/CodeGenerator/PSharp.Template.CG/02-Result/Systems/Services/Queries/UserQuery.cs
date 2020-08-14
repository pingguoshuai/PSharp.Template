using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Systems.Services.Queries {
    /// <summary>
    /// 管理员查询参数
    /// </summary>
    public class UserQuery : QueryParameter {
        /// <summary>
        /// Id
        /// </summary>
        [Display(Name="Id")]
        public Guid? Id { get; set; }
        
        private string _userName = string.Empty;
        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name="用户名")]
        public string UserName {
            get => _userName == null ? string.Empty : _userName.Trim();
            set => _userName = value;
        }
        
        private string _normalizedUserName = string.Empty;
        /// <summary>
        /// 标准化用户名
        /// </summary>
        [Display(Name="标准化用户名")]
        public string NormalizedUserName {
            get => _normalizedUserName == null ? string.Empty : _normalizedUserName.Trim();
            set => _normalizedUserName = value;
        }
        
        private string _nickName = string.Empty;
        /// <summary>
        /// 昵称
        /// </summary>
        [Display(Name="昵称")]
        public string NickName {
            get => _nickName == null ? string.Empty : _nickName.Trim();
            set => _nickName = value;
        }
        
        private string _name = string.Empty;
        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name="姓名")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        
        private string _email = string.Empty;
        /// <summary>
        /// 安全邮箱
        /// </summary>
        [Display(Name="安全邮箱")]
        public string Email {
            get => _email == null ? string.Empty : _email.Trim();
            set => _email = value;
        }
        
        private string _normalizedEmail = string.Empty;
        /// <summary>
        /// 标准化邮箱
        /// </summary>
        [Display(Name="标准化邮箱")]
        public string NormalizedEmail {
            get => _normalizedEmail == null ? string.Empty : _normalizedEmail.Trim();
            set => _normalizedEmail = value;
        }
        /// <summary>
        /// 邮箱已确认
        /// </summary>
        [Display(Name="邮箱已确认")]
        public bool? EmailConfirmed { get; set; }
        
        private string _phoneNumber = string.Empty;
        /// <summary>
        /// 安全手机
        /// </summary>
        [Display(Name="安全手机")]
        public string PhoneNumber {
            get => _phoneNumber == null ? string.Empty : _phoneNumber.Trim();
            set => _phoneNumber = value;
        }
        /// <summary>
        /// 手机已确认
        /// </summary>
        [Display(Name="手机已确认")]
        public bool? PhoneNumberConfirmed { get; set; }
        
        private string _password = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name="密码")]
        public string Password {
            get => _password == null ? string.Empty : _password.Trim();
            set => _password = value;
        }
        
        private string _passwordHash = string.Empty;
        /// <summary>
        /// 密码散列
        /// </summary>
        [Display(Name="密码散列")]
        public string PasswordHash {
            get => _passwordHash == null ? string.Empty : _passwordHash.Trim();
            set => _passwordHash = value;
        }
        
        private string _safePassword = string.Empty;
        /// <summary>
        /// 安全码
        /// </summary>
        [Display(Name="安全码")]
        public string SafePassword {
            get => _safePassword == null ? string.Empty : _safePassword.Trim();
            set => _safePassword = value;
        }
        
        private string _safePasswordHash = string.Empty;
        /// <summary>
        /// 安全码散列
        /// </summary>
        [Display(Name="安全码散列")]
        public string SafePasswordHash {
            get => _safePasswordHash == null ? string.Empty : _safePasswordHash.Trim();
            set => _safePasswordHash = value;
        }
        /// <summary>
        /// 启用锁定
        /// </summary>
        [Display(Name="启用锁定")]
        public bool? LockoutEnabled { get; set; }
        /// <summary>
        /// 起始锁定截止
        /// </summary>
        [Display( Name = "起始锁定截止" )]
        public DateTime? BeginLockoutEnd { get; set; }
        /// <summary>
        /// 结束锁定截止
        /// </summary>
        [Display( Name = "结束锁定截止" )]
        public DateTime? EndLockoutEnd { get; set; }
        /// <summary>
        /// 起始上次登陆时间
        /// </summary>
        [Display( Name = "起始上次登陆时间" )]
        public DateTime? BeginLastLoginTime { get; set; }
        /// <summary>
        /// 结束上次登陆时间
        /// </summary>
        [Display( Name = "结束上次登陆时间" )]
        public DateTime? EndLastLoginTime { get; set; }
        
        private string _lastLoginIp = string.Empty;
        /// <summary>
        /// 上次登陆Ip
        /// </summary>
        [Display(Name="上次登陆Ip")]
        public string LastLoginIp {
            get => _lastLoginIp == null ? string.Empty : _lastLoginIp.Trim();
            set => _lastLoginIp = value;
        }
        /// <summary>
        /// 起始本次登陆时间
        /// </summary>
        [Display( Name = "起始本次登陆时间" )]
        public DateTime? BeginCurrentLoginTime { get; set; }
        /// <summary>
        /// 结束本次登陆时间
        /// </summary>
        [Display( Name = "结束本次登陆时间" )]
        public DateTime? EndCurrentLoginTime { get; set; }
        
        private string _currentLoginIp = string.Empty;
        /// <summary>
        /// 本次登陆Ip
        /// </summary>
        [Display(Name="本次登陆Ip")]
        public string CurrentLoginIp {
            get => _currentLoginIp == null ? string.Empty : _currentLoginIp.Trim();
            set => _currentLoginIp = value;
        }
        /// <summary>
        /// 登陆次数
        /// </summary>
        [Display(Name="登陆次数")]
        public int? LoginCount { get; set; }
        /// <summary>
        /// 登陆失败次数
        /// </summary>
        [Display(Name="登陆失败次数")]
        public int? AccessFailedCount { get; set; }
        /// <summary>
        /// 启用两阶段认证
        /// </summary>
        [Display(Name="启用两阶段认证")]
        public bool? TwoFactorEnabled { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name="启用")]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 起始冻结时间
        /// </summary>
        [Display( Name = "起始冻结时间" )]
        public DateTime? BeginDisabledTime { get; set; }
        /// <summary>
        /// 结束冻结时间
        /// </summary>
        [Display( Name = "结束冻结时间" )]
        public DateTime? EndDisabledTime { get; set; }
        
        private string _registerIp = string.Empty;
        /// <summary>
        /// 注册Ip
        /// </summary>
        [Display(Name="注册Ip")]
        public string RegisterIp {
            get => _registerIp == null ? string.Empty : _registerIp.Trim();
            set => _registerIp = value;
        }
        
        private string _securityStamp = string.Empty;
        /// <summary>
        /// 安全戳
        /// </summary>
        [Display(Name="安全戳")]
        public string SecurityStamp {
            get => _securityStamp == null ? string.Empty : _securityStamp.Trim();
            set => _securityStamp = value;
        }
        
        private string _remark = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name="备注")]
        public string Remark {
            get => _remark == null ? string.Empty : _remark.Trim();
            set => _remark = value;
        }
        /// <summary>
        /// 起始创建时间
        /// </summary>
        [Display( Name = "起始创建时间" )]
        public DateTime? BeginCreationTime { get; set; }
        /// <summary>
        /// 结束创建时间
        /// </summary>
        [Display( Name = "结束创建时间" )]
        public DateTime? EndCreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        /// </summary>
        [Display(Name="创建人标识")]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 起始最后修改时间
        /// </summary>
        [Display( Name = "起始最后修改时间" )]
        public DateTime? BeginLastModificationTime { get; set; }
        /// <summary>
        /// 结束最后修改时间
        /// </summary>
        [Display( Name = "结束最后修改时间" )]
        public DateTime? EndLastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        /// </summary>
        [Display(Name="最后修改人标识")]
        public Guid? LastModifierId { get; set; }
    }
}