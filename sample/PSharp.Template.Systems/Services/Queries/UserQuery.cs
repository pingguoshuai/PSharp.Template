using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Systems.Services.Queries {
    /// <summary>
    /// 查询参数
    /// </summary>
    public class UserQuery : QueryParameter {

        private string _userName = string.Empty;
        /// <summary>
        /// UserName
        /// </summary>
        [Display(Name = "UserName")]
        public string UserName
        {
            get => _userName == null ? string.Empty : _userName.Trim();
            set => _userName = value;
        }

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

        private string _phoneNumber = string.Empty;
        /// <summary>
        /// PhoneNumber
        /// </summary>
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber
        {
            get => _phoneNumber == null ? string.Empty : _phoneNumber.Trim();
            set => _phoneNumber = value;
        }
    }
}