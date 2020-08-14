using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Data;

namespace PSharp.Template.Systems.Services.Dtos {
    /// <summary>
    /// 身份资源数据传输对象
    /// </summary>
    public class ResourceDto : TreeDto<ResourceDto> {
        /// <summary>
        /// Version
        /// </summary>
        [Display( Name = "Version" )]
        public Byte[] Version { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage = "Name不能为空")]
        [StringLength( 800 )]
        [Display( Name = "Name" )]
        public string Name { get; set; }
        /// <summary>
        /// RouteName
        /// </summary>
        [StringLength( 800 )]
        [Display( Name = "RouteName" )]
        public string RouteName { get; set; }
        /// <summary>
        /// RouteUri
        /// </summary>
        [Required(ErrorMessage = "RouteUri不能为空")]
        [StringLength( 1200 )]
        [Display( Name = "RouteUri" )]
        public string RouteUri { get; set; }
        /// <summary>
        /// 资源类型
        /// </summary>
        [Required(ErrorMessage = "资源类型不能为空")]
        [Display( Name = "资源类型" )]
        public int Type { get; set; }
        /// <summary>
        /// IsHide
        /// </summary>
        [Display( Name = "IsHide" )]
        public bool? IsHide { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [StringLength( 200 )]
        [Display( Name = "图标" )]
        public string Icon { get; set; }
        /// <summary>
        /// KeepAlive
        /// </summary>
        [Display( Name = "KeepAlive" )]
        public bool? KeepAlive { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        [StringLength( 2000 )]
        [Display( Name = "Remark" )]
        public string Remark { get; set; }
        /// <summary>
        /// Required
        /// </summary>
        [Display( Name = "Required" )]
        public bool? Required { get; set; }
        /// <summary>
        /// CreationTime
        /// </summary>
        [Display( Name = "CreationTime" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// CreatorId
        /// </summary>
        [Display( Name = "CreatorId" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// LastModificationTime
        /// </summary>
        [Display( Name = "LastModificationTime" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// LastModifierId
        /// </summary>
        [Display( Name = "LastModifierId" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// ApplicationId
        /// </summary>
        [Display( Name = "ApplicationId" )]
        public Guid? ApplicationId { get; set; }
    }
}