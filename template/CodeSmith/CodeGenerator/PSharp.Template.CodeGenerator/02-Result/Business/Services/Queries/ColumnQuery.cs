using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Business.Services.Queries {
    /// <summary>
    /// 栏目查询参数
    /// </summary>
    public class ColumnQuery : QueryParameter {
        /// <summary>
        /// Id
        /// </summary>
        [Display(Name="Id")]
        public Guid? Id { get; set; }
        /// <summary>
        /// ParentId
        /// </summary>
        [Display(Name="ParentId")]
        public Guid? ParentId { get; set; }
        
        private string _name = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name="名称")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        /// <summary>
        /// 图片
        /// </summary>
        [Display(Name="图片")]
        public Guid? IconId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Display(Name="类型")]
        public Guid? TypeId { get; set; }
        
        private string _diyName = string.Empty;
        /// <summary>
        /// 自定义名称
        /// </summary>
        [Display(Name="自定义名称")]
        public string DiyName {
            get => _diyName == null ? string.Empty : _diyName.Trim();
            set => _diyName = value;
        }
        
        private string _keywords = string.Empty;
        /// <summary>
        /// 关键字
        /// </summary>
        [Display(Name="关键字")]
        public string Keywords {
            get => _keywords == null ? string.Empty : _keywords.Trim();
            set => _keywords = value;
        }
        
        private string _descrition = string.Empty;
        /// <summary>
        /// 页面描述
        /// </summary>
        [Display(Name="页面描述")]
        public string Descrition {
            get => _descrition == null ? string.Empty : _descrition.Trim();
            set => _descrition = value;
        }
        
        private string _outLink = string.Empty;
        /// <summary>
        /// 链接
        /// </summary>
        [Display(Name="链接")]
        public string OutLink {
            get => _outLink == null ? string.Empty : _outLink.Trim();
            set => _outLink = value;
        }
        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name="排序")]
        public int? Sort { get; set; }
        /// <summary>
        /// 分页大小
        /// </summary>
        [Display(Name="分页大小")]
        public int? PageSize { get; set; }
        /// <summary>
        /// 是否可投稿
        /// </summary>
        [Display(Name="是否可投稿")]
        public bool? IsContribute { get; set; }
        /// <summary>
        /// 导航显示
        /// </summary>
        [Display(Name="导航显示")]
        public bool? IsNav { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name="状态")]
        public bool? Status { get; set; }
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
        
        private string _tenantId = string.Empty;
        /// <summary>
        /// TenantId
        /// </summary>
        [Display(Name="TenantId")]
        public string TenantId {
            get => _tenantId == null ? string.Empty : _tenantId.Trim();
            set => _tenantId = value;
        }
    }
}