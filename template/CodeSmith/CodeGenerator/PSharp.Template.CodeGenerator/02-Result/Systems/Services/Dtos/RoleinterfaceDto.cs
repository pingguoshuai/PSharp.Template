using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using Util.Applications.Dtos;

namespace PSharp.Template.Systems.Services.Dtos {
    /// <summary>
    /// 角色接口参数
    /// </summary>
    public class RoleinterfaceDto : DtoBase {
        /// <summary>
        /// 角色标识
        /// </summary>
        [Required(ErrorMessage = "角色标识不能为空")]
        [Display( Name = "角色标识" )]
        public Guid RoleId { get; set; }
        /// <summary>
        /// 接口标识
        /// </summary>
        [StringLength( 2147483647 )]
        [Display( Name = "接口标识" )]
        public string InterfaceCode { get; set; }
        /// <summary>
        /// 应用程序标识
        /// </summary>
        [Required(ErrorMessage = "应用程序标识不能为空")]
        [Display( Name = "应用程序标识" )]
        public Guid ApplicationId { get; set; }
    }
}