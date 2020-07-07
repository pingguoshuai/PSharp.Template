using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Common.Services.Queries {
    /// <summary>
    /// 查询参数
    /// </summary>
    public class DicTypeQuery : QueryParameter {
        
        private string _name = string.Empty;
        /// <summary>
        /// 字典类型名称
        /// </summary>
        [Display(Name="Name")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        
        private string _code = string.Empty;
        /// <summary>
        /// 字典类型编码
        /// </summary>
        [Display(Name="Code")]
        public string Code {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }
        /// <summary>
        /// 启用
        /// </summary>
        [Display(Name="Status")]
        public bool? Status { get; set; }
    }
}