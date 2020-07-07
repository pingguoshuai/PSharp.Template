using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PSharp.Template.Systems.Domains.Enums;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Domains.Trees;

namespace PSharp.Template.Systems.Domains.Models
{
    [Table("Systems.Resource")]
    [Description("身份资源")]
    public partial class Resource : TreeEntityBase<Resource>, IAudited
    {
        /// <summary>
        /// 初始化身份资源
        /// </summary>
        public Resource() : this(Guid.Empty, "", 0)
        {
        }

        /// <summary>
        /// 初始化身份资源
        /// </summary>
        public Resource(Guid id, string path, int level) : base(id, path, level)
        {
        }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required(ErrorMessage = "菜单名称不能为空")]
        [StringLength(200)]
        public string Name { get; set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        [StringLength(200)]
        public string RouteName { get; set; }
        /// <summary>
        /// 路由地址
        /// </summary>
        [Required(ErrorMessage = "路由地址不能为空")]
        [StringLength(300)]
        public string RouteUri { get; set; }
        /// <summary>
        /// 资源类型
        /// </summary>  
        [DisplayName("资源类型")]
        public ResourceType Type { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool? IsHide { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [StringLength(50)]
        [DisplayName("图标")]
        public string Icon { get; set; }
        /// <summary>
        /// KeepAlive
        /// </summary>
        public bool? KeepAlive { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }
        /// <summary>
        /// 必选
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        /// </summary>
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        /// </summary>
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// IsDeleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 应用程序
        /// </summary>
        public Guid? ApplicationId { get; set; }
        public Application Application { get; set; }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions()
        {
            AddDescription(t => t.Id);
            AddDescription(t => t.ParentId);
            AddDescription(t => t.Path);
            AddDescription(t => t.Level);
            AddDescription(t => t.Enabled);
            AddDescription(t => t.SortId);
            AddDescription(t => t.Name);
            AddDescription(t => t.RouteName);
            AddDescription(t => t.RouteUri);
            AddDescription(t => t.Type);
            AddDescription(t => t.IsHide);
            AddDescription(t => t.KeepAlive);
            AddDescription(t => t.Remark);
            AddDescription(t => t.Required);
            AddDescription(t => t.CreationTime);
            AddDescription(t => t.CreatorId);
            AddDescription(t => t.LastModificationTime);
            AddDescription(t => t.LastModifierId);
            AddDescription(t => t.ApplicationId);
        }

        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges(Resource other)
        {
            AddChange(t => t.Id, other.Id);
            AddChange(t => t.ParentId, other.ParentId);
            AddChange(t => t.Path, other.Path);
            AddChange(t => t.Level, other.Level);
            AddChange(t => t.Enabled, other.Enabled);
            AddChange(t => t.SortId, other.SortId);
            AddChange(t => t.Name, other.Name);
            AddChange(t => t.RouteName, other.RouteName);
            AddChange(t => t.RouteUri, other.RouteUri);
            AddChange(t => t.Type, other.Type);
            AddChange(t => t.IsHide, other.IsHide);
            AddChange(t => t.KeepAlive, other.KeepAlive);
            AddChange(t => t.Remark, other.Remark);
            AddChange(t => t.Required, other.Required);
            AddChange(t => t.CreationTime, other.CreationTime);
            AddChange(t => t.CreatorId, other.CreatorId);
            AddChange(t => t.LastModificationTime, other.LastModificationTime);
            AddChange(t => t.LastModifierId, other.LastModifierId);
            AddChange(t => t.ApplicationId, other.ApplicationId);
        }
    }
}
