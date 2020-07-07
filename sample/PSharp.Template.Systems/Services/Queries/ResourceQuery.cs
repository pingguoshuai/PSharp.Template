using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Datas.Queries.Trees;

namespace PSharp.Template.Systems.Services.Queries {
    /// <summary>
    /// 查询参数
    /// </summary>
    public class ResourceQuery : TreeQueryParameter {
        /// <summary>
        /// Id
        /// </summary>
        [Display(Name="Id")]
        public Guid? Id { get; set; }
        
        /// <summary>
        /// ApplicationId
        /// </summary>
        [Display(Name="ApplicationId")]
        public Guid? ApplicationId { get; set; }
    }
}