using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries;

namespace PSharp.Template.Systems.Services.Queries {
    /// <summary>
    /// 角色接口查询参数
    /// </summary>
    public class RoleinterfaceQuery : QueryParameter {
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
        
        private string _interfaceCode = string.Empty;
        /// <summary>
        /// 接口标识
        /// </summary>
        [Display(Name="接口标识")]
        public string InterfaceCode {
            get => _interfaceCode == null ? string.Empty : _interfaceCode.Trim();
            set => _interfaceCode = value;
        }
        /// <summary>
        /// 应用程序标识
        /// </summary>
        [Display(Name="应用程序标识")]
        public Guid? ApplicationId { get; set; }
    }
}