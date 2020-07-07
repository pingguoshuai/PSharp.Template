using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Common.Services.Queries {
    /// <summary>
    /// 查询参数
    /// </summary>
    public class DicInfoQuery : QueryParameter {
        /// <summary>
        /// DicTypeId
        /// </summary>
        [Display(Name="DicTypeId")]
        public Guid? DicTypeId { get; set; }

        private string _name = string.Empty;
        /// <summary>
        /// Name
        /// </summary>
        [Display(Name="Name")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        
        private string _value = string.Empty;
        /// <summary>
        /// Value
        /// </summary>
        [Display(Name="Value")]
        public string Value {
            get => _value == null ? string.Empty : _value.Trim();
            set => _value = value;
        }
        /// <summary>
        /// Status
        /// </summary>
        [Display(Name="Status")]
        public bool? Status { get; set; }
        
    }
}