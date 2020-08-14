using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries.Trees;

namespace PSharp.Template.Systems.Services.Queries {
    /// <summary>
    /// 角色查询参数
    /// </summary>
    public class RoleQuery : TreeQueryParameter {
        /// <summary>
        /// Id
        /// </summary>
        [Display(Name="Id")]
        public Guid? Id { get; set; }
        
        private string _code = string.Empty;
        /// <summary>
        /// Code
        /// </summary>
        [Display(Name="Code")]
        public string Code {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }
        
        private string _name = string.Empty;
        /// <summary>
        /// 角色名称
        /// </summary>
        [Display(Name="角色名称")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        
        private string _normalizedName = string.Empty;
        /// <summary>
        /// NormalizedName
        /// </summary>
        [Display(Name="NormalizedName")]
        public string NormalizedName {
            get => _normalizedName == null ? string.Empty : _normalizedName.Trim();
            set => _normalizedName = value;
        }
        
        private string _type = string.Empty;
        /// <summary>
        /// Type
        /// </summary>
        [Display(Name="Type")]
        public string Type {
            get => _type == null ? string.Empty : _type.Trim();
            set => _type = value;
        }
        /// <summary>
        /// IsAdmin
        /// </summary>
        [Display(Name="IsAdmin")]
        public bool? IsAdmin { get; set; }
        
        private string _remark = string.Empty;
        /// <summary>
        /// Remark
        /// </summary>
        [Display(Name="Remark")]
        public string Remark {
            get => _remark == null ? string.Empty : _remark.Trim();
            set => _remark = value;
        }
        
        private string _pinYin = string.Empty;
        /// <summary>
        /// PinYin
        /// </summary>
        [Display(Name="PinYin")]
        public string PinYin {
            get => _pinYin == null ? string.Empty : _pinYin.Trim();
            set => _pinYin = value;
        }
        
        private string _sign = string.Empty;
        /// <summary>
        /// Sign
        /// </summary>
        [Display(Name="Sign")]
        public string Sign {
            get => _sign == null ? string.Empty : _sign.Trim();
            set => _sign = value;
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