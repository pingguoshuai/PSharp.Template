using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Util;
using Util.Applications.Dtos;
using Util.Exceptions;
using Util.Validations;

namespace PSharp.Template.Systems.Services.Dtos.Requests
{
    public class LoginRequest : RequestBase
    {
        /// <summary>
        /// 帐号，可以是用户名，手机号或电子邮件
        /// </summary>
        [Display(Name = "帐号")]
        public string Account { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Display(Name = "手机号")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 应用程序编码
        /// </summary>
        [Required(ErrorMessage = "应用程序编码不能为空")]
        public string ApplicationCode { get; set; }

        /// <summary>
        /// 记住密码
        /// </summary>
        [Display(Name = "记住密码")]
        public bool? Remember { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        public override ValidationResultCollection Validate()
        {
            if (Account.IsEmpty() && UserName.IsEmpty() && Email.IsEmpty() && PhoneNumber.IsEmpty())
                throw new Warning("帐号不能为空");
            return base.Validate();
        }
    }
}
