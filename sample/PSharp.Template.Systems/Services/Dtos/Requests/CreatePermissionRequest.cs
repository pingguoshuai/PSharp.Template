using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using PSharp.Template.Core.Applications.Dtos;

namespace PSharp.Template.Systems.Services.Dtos.Requests {
    /// <summary>
    /// 参数
    /// </summary>
    public class CreatePermissionRequest : RequestBase
    {
        /// <summary>
        /// 应用程序标识
        /// </summary>
        public Guid? ApplicationId { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>
        [Required(ErrorMessage = "RoleId不能为空")]
        [Display( Name = "RoleId" )]
        public Guid RoleId { get; set; }

        /// <summary>
        /// 资源标识
        /// </summary>
        public string ResourceIds { get; set; }

        /// <summary>
        /// IsDeny
        /// </summary>
        [Display( Name = "IsDeny" )]
        public bool? IsDeny { get; set; }
    }
}