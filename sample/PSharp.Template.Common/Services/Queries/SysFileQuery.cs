using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Common.Services.Queries {
    /// <summary>
    /// 查询参数
    /// </summary>
    public class SysFileQuery : QueryParameter {
        /// <summary>
        /// Id
        /// </summary>
        [Display(Name="Id")]
        public Guid? Id { get; set; }
        
        private string _oldName = string.Empty;
        /// <summary>
        /// OldName
        /// </summary>
        [Display(Name="OldName")]
        public string OldName {
            get => _oldName == null ? string.Empty : _oldName.Trim();
            set => _oldName = value;
        }
        
        private string _newName = string.Empty;
        /// <summary>
        /// NewName
        /// </summary>
        [Display(Name="NewName")]
        public string NewName {
            get => _newName == null ? string.Empty : _newName.Trim();
            set => _newName = value;
        }
        
        private string _extension = string.Empty;
        /// <summary>
        /// Extension
        /// </summary>
        [Display(Name="Extension")]
        public string Extension {
            get => _extension == null ? string.Empty : _extension.Trim();
            set => _extension = value;
        }
        /// <summary>
        /// Size
        /// </summary>
        [Display(Name="Size")]
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
        /// Src
        /// </summary>
        [Display(Name="Src")]
        public string Src {
            get => _src == null ? string.Empty : _src.Trim();
            set => _src = value;
        }
        
    }
}