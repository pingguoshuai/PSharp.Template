using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSharp.Template.Systems.Services.Dtos.Requests
{
    public class CreateRoleInterfaceRequest
    {
        /// <summary>
        /// 应用程序标识
        /// </summary>
        public Guid? ApplicationId { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>
        [Required(ErrorMessage = "RoleId不能为空")]
        [Display(Name = "RoleId")]
        public Guid RoleId { get; set; }

        /// <summary>
        /// 接口codes
        /// </summary>
        public string InterfaceCodes { get; set; }
    }
}
