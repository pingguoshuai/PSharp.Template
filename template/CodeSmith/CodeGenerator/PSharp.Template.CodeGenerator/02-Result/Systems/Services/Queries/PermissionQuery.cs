using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Systems.Services.Queries {
    /// <summary>
    /// 权限查询参数
    /// </summary>
    public class PermissionQuery : QueryParameter {
        /// <summary>
        /// Id
        /// </summary>
        [Display(Name="Id")]
        public Guid? Id { get; set; }
        /// <summary>
        /// 角色标识
        /// </summary>
        [Display(Name="角色标识")]
        public Guid? RoleId { get; set; }
        /// <summary>
        /// 资源标识
        /// </summary>
        [Display(Name="资源标识")]
        public Guid? ResourceId { get; set; }
        /// <summary>
        /// 拒绝
        /// </summary>
        [Display(Name="拒绝")]
        public bool? IsDeny { get; set; }
        
        private string _sign = string.Empty;
        /// <summary>
        /// 签名
        /// </summary>
        [Display(Name="签名")]
        public string Sign {
            get => _sign == null ? string.Empty : _sign.Trim();
            set => _sign = value;
        }
        /// <summary>
        /// 起始创建时间
        /// </summary>
        [Display( Name = "起始创建时间" )]
        public DateTime? BeginCreationTime { get; set; }
        /// <summary>
        /// 结束创建时间
        /// </summary>
        [Display( Name = "结束创建时间" )]
        public DateTime? EndCreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        /// </summary>
        [Display(Name="创建人标识")]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 起始最后修改时间
        /// </summary>
        [Display( Name = "起始最后修改时间" )]
        public DateTime? BeginLastModificationTime { get; set; }
        /// <summary>
        /// 结束最后修改时间
        /// </summary>
        [Display( Name = "结束最后修改时间" )]
        public DateTime? EndLastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        /// </summary>
        [Display(Name="最后修改人标识")]
        public Guid? LastModifierId { get; set; }
    }
}