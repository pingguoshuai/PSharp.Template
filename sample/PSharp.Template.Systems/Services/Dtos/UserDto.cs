using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;

namespace PSharp.Template.Systems.Services.Dtos {
    /// <summary>
    /// 参数
    /// </summary>
    public class UserDto : DtoBase {
        /// <summary>
        /// UserName
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "UserName" )]
        public string UserName { get; set; }

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
        /// Email
        /// </summary>
        [StringLength( 256 )]
        [Display( Name = "Email" )]
        public string Email { get; set; }
        /// <summary>
        /// PhoneNumber
        /// </summary>
        [StringLength( 64 )]
        [Display( Name = "PhoneNumber" )]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// LastLoginTime
        /// </summary>
        [Display( Name = "LastLoginTime" )]
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// LastLoginIp
        /// </summary>
        [StringLength( 30 )]
        [Display( Name = "LastLoginIp" )]
        public string LastLoginIp { get; set; }
        /// <summary>
        /// CurrentLoginTime
        /// </summary>
        [Display( Name = "CurrentLoginTime" )]
        public DateTime? CurrentLoginTime { get; set; }
        /// <summary>
        /// CurrentLoginIp
        /// </summary>
        [StringLength( 30 )]
        [Display( Name = "CurrentLoginIp" )]
        public string CurrentLoginIp { get; set; }
        /// <summary>
        /// RegisterIp
        /// </summary>
        [StringLength( 30 )]
        [Display( Name = "RegisterIp" )]
        public string RegisterIp { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name = "启用")]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        [Display(Name = "登录次数")]
        public int? LoginCount { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        [Display(Name = "版本号")]
        public Byte[] Version { get; set; }
        public string Token { get; set; }
    }
}