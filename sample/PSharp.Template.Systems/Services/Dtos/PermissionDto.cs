using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using PSharp.Template.Systems.Domains.Models;
using Util.Ui.Attributes;
using Util.Applications.Dtos;

namespace PSharp.Template.Systems.Services.Dtos {
    /// <summary>
    /// 参数
    /// </summary>
    public class PermissionDto : DtoBase {
        /// <summary>
        /// Version
        /// </summary>
        [Display(Name = "Version")]
        public Byte[] Version { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>
        [Required(ErrorMessage = "RoleId不能为空")]
        [Display(Name = "RoleId")]
        public Guid RoleId { get; set; }
        /// <summary>
        /// ResourceId
        /// </summary>
        [Required(ErrorMessage = "ResourceId不能为空")]
        [Display(Name = "ResourceId")]
        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; }
        /// <summary>
        /// IsDeny
        /// </summary>
        [Display(Name = "IsDeny")]
        public bool? IsDeny { get; set; }
    }
}