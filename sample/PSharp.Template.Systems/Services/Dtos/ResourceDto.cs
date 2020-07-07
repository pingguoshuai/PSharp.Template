using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using PSharp.Template.Systems.Domains.Enums;
using Util.Ui.Data;

namespace PSharp.Template.Systems.Services.Dtos {
    /// <summary>
    /// 数据传输对象
    /// </summary>
    public class ResourceDto : TreeDto<ResourceDto> {
        /// <summary>
        /// Version
        /// </summary>
        [Display( Name = "Version" )]
        public Byte[] Version { get; set; }
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
        public string TypeText { get; set; }


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
        public override string Icon { get; set; }
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
        /// 必选
        /// </summary>
        [Display(Name = "必选")]
        public bool? Required { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        /// </summary>
        [Display(Name = "创建人标识")]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Display(Name = "最后修改时间")]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        /// </summary>
        [Display(Name = "最后修改人标识")]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 应用程序
        /// </summary>
        [Display(Name = "应用程序")]
        public Guid? ApplicationId { get; set; }

        #region tree使用

        public string Key { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }

        #endregion
    }
}