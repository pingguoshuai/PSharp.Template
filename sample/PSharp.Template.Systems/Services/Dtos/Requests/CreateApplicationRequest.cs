using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using PSharp.Template.Core.Applications.Dtos;

namespace PSharp.Template.Systems.Services.Dtos.Requests {
    /// <summary>
    /// 参数
    /// </summary>
    public class CreateApplicationRequest : RequestBase {
        /// <summary>
        /// Code
        /// </summary>
        [Required(ErrorMessage = "Code不能为空")]
        [StringLength( 60 )]
        [Display( Name = "Code" )]
        public string Code { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required(ErrorMessage = "Name不能为空")]
        [StringLength( 200 )]
        [Display( Name = "Name" )]
        public string Name { get; set; }
        /// <summary>
        /// Enabled
        /// </summary>
        [Display( Name = "Enabled" )]
        public bool? Enabled { get; set; }
        /// <summary>
        /// RegisterEnabled
        /// </summary>
        [Display( Name = "RegisterEnabled" )]
        public bool? RegisterEnabled { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        [StringLength( 500 )]
        [Display( Name = "Remark" )]
        public string Remark { get; set; }
        /// <summary>
        /// CreationTime
        /// </summary>
        [Display( Name = "CreationTime" )]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// CreatorId
        /// </summary>
        [Display( Name = "CreatorId" )]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// LastModificationTime
        /// </summary>
        [Display( Name = "LastModificationTime" )]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// LastModifierId
        /// </summary>
        [Display( Name = "LastModifierId" )]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// ApplicationType
        /// </summary>
        [Required(ErrorMessage = "ApplicationType不能为空")]
        [Display( Name = "ApplicationType" )]
        public int ApplicationType { get; set; }
        /// <summary>
        /// IsClient
        /// </summary>
        [Display( Name = "IsClient" )]
        public bool? IsClient { get; set; }
    }
}