using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries.Trees;

namespace PSharp.Template.Systems.Services.Queries {
    /// <summary>
    /// 身份资源查询参数
    /// </summary>
    public class ResourceQuery : TreeQueryParameter {
        /// <summary>
        /// Id
        /// </summary>
        [Display(Name="Id")]
        public Guid? Id { get; set; }
        
        private string _name = string.Empty;
        /// <summary>
        /// Name
        /// </summary>
        [Display(Name="Name")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        
        private string _routeName = string.Empty;
        /// <summary>
        /// RouteName
        /// </summary>
        [Display(Name="RouteName")]
        public string RouteName {
            get => _routeName == null ? string.Empty : _routeName.Trim();
            set => _routeName = value;
        }
        
        private string _routeUri = string.Empty;
        /// <summary>
        /// RouteUri
        /// </summary>
        [Display(Name="RouteUri")]
        public string RouteUri {
            get => _routeUri == null ? string.Empty : _routeUri.Trim();
            set => _routeUri = value;
        }
        /// <summary>
        /// 资源类型
        /// </summary>
        [Display(Name="资源类型")]
        public int? Type { get; set; }
        /// <summary>
        /// IsHide
        /// </summary>
        [Display(Name="IsHide")]
        public bool? IsHide { get; set; }
        
        private string _icon = string.Empty;
        /// <summary>
        /// 图标
        /// </summary>
        [Display(Name="图标")]
        public string Icon {
            get => _icon == null ? string.Empty : _icon.Trim();
            set => _icon = value;
        }
        /// <summary>
        /// KeepAlive
        /// </summary>
        [Display(Name="KeepAlive")]
        public bool? KeepAlive { get; set; }
        
        private string _remark = string.Empty;
        /// <summary>
        /// Remark
        /// </summary>
        [Display(Name="Remark")]
        public string Remark {
            get => _remark == null ? string.Empty : _remark.Trim();
            set => _remark = value;
        }
        /// <summary>
        /// Required
        /// </summary>
        [Display(Name="Required")]
        public bool? Required { get; set; }
        /// <summary>
        /// 起始CreationTime
        /// </summary>
        [Display( Name = "起始CreationTime" )]
        public DateTime? BeginCreationTime { get; set; }
        /// <summary>
        /// 结束CreationTime
        /// </summary>
        [Display( Name = "结束CreationTime" )]
        public DateTime? EndCreationTime { get; set; }
        /// <summary>
        /// CreatorId
        /// </summary>
        [Display(Name="CreatorId")]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 起始LastModificationTime
        /// </summary>
        [Display( Name = "起始LastModificationTime" )]
        public DateTime? BeginLastModificationTime { get; set; }
        /// <summary>
        /// 结束LastModificationTime
        /// </summary>
        [Display( Name = "结束LastModificationTime" )]
        public DateTime? EndLastModificationTime { get; set; }
        /// <summary>
        /// LastModifierId
        /// </summary>
        [Display(Name="LastModifierId")]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// ApplicationId
        /// </summary>
        [Display(Name="ApplicationId")]
        public Guid? ApplicationId { get; set; }
    }
}