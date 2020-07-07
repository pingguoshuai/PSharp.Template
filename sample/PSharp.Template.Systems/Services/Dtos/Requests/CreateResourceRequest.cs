using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using PSharp.Template.Core.Applications.Dtos;
using PSharp.Template.Systems.Domains.Enums;

namespace PSharp.Template.Systems.Services.Dtos.Requests {
    /// <summary>
    /// 参数
    /// </summary>
    public class CreateResourceRequest : RequestBase {
        /// <summary>
        /// ParentId
        /// </summary>
        [Display( Name = "ParentId" )]
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        [Display( Name = "Enabled" )]
        public bool? Enabled { get; set; }
        /// <summary>
        /// SortId
        /// </summary>
        [Display( Name = "SortId" )]
        public int? SortId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required(ErrorMessage = "菜单名称不能为空")]
        [StringLength(200)]
        [Display(Name = "菜单名称")]
        public string Name { get; set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        [StringLength(200)]
        [Display(Name = "路由名称")]
        public string RouteName { get; set; }
        /// <summary>
        /// 路由地址
        /// </summary>
        [Required(ErrorMessage = "路由地址不能为空")]
        [StringLength(300)]
        [Display(Name = "路由地址")]
        public string RouteUri { get; set; }
        /// <summary>
        /// 资源类型
        /// </summary>
        [Display(Name = "资源类型")]
        public ResourceType Type { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        [Display(Name = "是否隐藏")]
        public bool? IsHide { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [Display(Name = "图标")]
        [StringLength(50)]
        public string Icon { get; set; }
        /// <summary>
        /// KeepAlive
        /// </summary>
        [Display(Name = "KeepAlive")]
        public bool? KeepAlive { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500)]
        [Display(Name = "备注")]
        public string Remark { get; set; }
        /// <summary>
        /// ApplicationId
        /// </summary>
        [Display( Name = "ApplicationId" )]
        public Guid? ApplicationId { get; set; }
    }
}