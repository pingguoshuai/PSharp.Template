using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PSharp.Template.Core.Applications.Dtos;

namespace PSharp.Template.Systems.Services.Dtos.Requests
{
    /// <summary>
    /// 参数
    /// </summary>
    public class UpdateUserRequest : RequestBase
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(256)]
        [Display(Name = "用户名")]
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
        /// 安全邮箱
        /// </summary>
        [StringLength(256)]
        [EmailAddress]
        [Display(Name = "邮箱")]
        public string Email { get; set; }
        /// <summary>
        /// 安全手机
        /// </summary>
        [StringLength(64)]
        [Phone]
        [Display(Name = "手机号")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(256)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name = "启用")]
        public bool Enabled { get; set; }
    }
}
