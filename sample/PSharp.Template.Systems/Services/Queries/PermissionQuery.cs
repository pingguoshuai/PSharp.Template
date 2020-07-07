using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Systems.Services.Queries {
    /// <summary>
    /// 查询参数
    /// </summary>
    public class PermissionQuery : QueryParameter
    {
        /// <summary>
        /// 应用程序标识
        /// </summary>
        public Guid? ApplicationId { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>
        [Display(Name="RoleId")]
        public Guid? RoleId { get; set; }
        /// <summary>
        /// ResourceId
        /// </summary>
        [Display(Name="ResourceId")]
        public Guid? ResourceId { get; set; }
        /// <summary>
        /// IsDeny
        /// </summary>
        [Display(Name="IsDeny")]
        public bool? IsDeny { get; set; }
        
        private string _sign = string.Empty;
        /// <summary>
        /// Sign
        /// </summary>
        [Display(Name="Sign")]
        public string Sign {
            get => _sign == null ? string.Empty : _sign.Trim();
            set => _sign = value;
        }
    }
}