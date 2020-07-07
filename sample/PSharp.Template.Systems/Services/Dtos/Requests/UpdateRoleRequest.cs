using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using PSharp.Template.Core.Applications.Dtos;

namespace PSharp.Template.Systems.Services.Dtos.Requests
{
    /// <summary>
    /// 修改角色参数
    /// </summary>
    public class UpdateRoleRequest : RequestBase
    {

        /// <summary>
        /// 角色编码
        /// </summary>
        [Required(ErrorMessage = "角色编码不能为空")]
        [StringLength(256)]
        [Display(Name = "角色编码")]
        public string Code { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required(ErrorMessage = "角色名称不能为空")]
        [StringLength(256)]
        [Display(Name = "角色名称")]
        public string Name { get; set; }

        /// <summary>
        /// 父角色标识
        /// </summary>
        [DataMember]
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name = "启用")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500)]
        [Display(Name = "备注")]
        public string Remark { get; set; }
    }
}
