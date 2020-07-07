using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Common.Services.Queries {
    /// <summary>
    /// 文件查询参数
    /// </summary>
    public class SysfileQuery : QueryParameter {
        /// <summary>
        /// Id
        /// </summary>
        [Display(Name="Id")]
        public Guid? Id { get; set; }
        
        private string _oldName = string.Empty;
        /// <summary>
        /// 原名称
        /// </summary>
        [Display(Name="原名称")]
        public string OldName {
            get => _oldName == null ? string.Empty : _oldName.Trim();
            set => _oldName = value;
        }
        
        private string _newName = string.Empty;
        /// <summary>
        /// 新名称
        /// </summary>
        [Display(Name="新名称")]
        public string NewName {
            get => _newName == null ? string.Empty : _newName.Trim();
            set => _newName = value;
        }
        
        private string _extension = string.Empty;
        /// <summary>
        /// 扩展名
        /// </summary>
        [Display(Name="扩展名")]
        public string Extension {
            get => _extension == null ? string.Empty : _extension.Trim();
            set => _extension = value;
        }
        /// <summary>
        /// 大小
        /// </summary>
        [Display(Name="大小")]
        public int? Size { get; set; }
        
        private string _md5 = string.Empty;
        /// <summary>
        /// Md5
        /// </summary>
        [Display(Name="Md5")]
        public string Md5 {
            get => _md5 == null ? string.Empty : _md5.Trim();
            set => _md5 = value;
        }
        
        private string _src = string.Empty;
        /// <summary>
        /// 路径
        /// </summary>
        [Display(Name="路径")]
        public string Src {
            get => _src == null ? string.Empty : _src.Trim();
            set => _src = value;
        }
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
    }
}