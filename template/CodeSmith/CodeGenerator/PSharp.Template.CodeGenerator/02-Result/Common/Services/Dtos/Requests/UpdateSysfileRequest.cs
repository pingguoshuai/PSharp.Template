using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Ui.Attributes;
using PSharp.Template.Core.Applications.Dtos;

namespace PSharp.Template.Common.Services.Dtos.Requests {
    /// <summary>
    /// 文件参数
    /// </summary>
    public class UpdateSysfileRequest : RequestBase {
        /// <summary>
        /// 原名称
        /// </summary>
        [Required(ErrorMessage = "原名称不能为空")]
        [StringLength( 1200 )]
        [Display( Name = "原名称" )]
        public string OldName { get; set; }
        /// <summary>
        /// 新名称
        /// </summary>
        [Required(ErrorMessage = "新名称不能为空")]
        [StringLength( 1200 )]
        [Display( Name = "新名称" )]
        public string NewName { get; set; }
        /// <summary>
        /// 扩展名
        /// </summary>
        [Required(ErrorMessage = "扩展名不能为空")]
        [StringLength( 40 )]
        [Display( Name = "扩展名" )]
        public string Extension { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        [Required(ErrorMessage = "大小不能为空")]
        [Display( Name = "大小" )]
        public int Size { get; set; }
        /// <summary>
        /// Md5
        /// </summary>
        [Required(ErrorMessage = "Md5不能为空")]
        [StringLength( 256 )]
        [Display( Name = "Md5" )]
        public string Md5 { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        [Required(ErrorMessage = "路径不能为空")]
        [StringLength( 1020 )]
        [Display( Name = "路径" )]
        public string Src { get; set; }
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
    }
}