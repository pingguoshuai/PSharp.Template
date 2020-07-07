using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Util.Domains;
using Util.Domains.Auditing;

namespace PSharp.Template.Common.Domains.Models
{
    [Table("Common.SysFile")]
    [Description("文件")]
    public partial class SysFile : AggregateRoot<SysFile>, ICreationAudited, IModificationAudited, IDelete
    {
        public SysFile() : base(Guid.Empty)
        {

        }

        public SysFile(Guid id) : base(id)
        {
        }

        [DisplayName("原名称")]
        [StringLength(300)]
        [Required]
        public string OldName { get; set; }

        [DisplayName("新名称")]
        [StringLength(300)]
        [Required]
        public string NewName { get; set; }

        [DisplayName("扩展名")]
        [StringLength(10)]
        [Required]
        public string Extension { get; set; }

        [DisplayName("大小")]
        public int Size { get; set; } = 0;

        [DisplayName("Md5")]
        [StringLength(64)]
        [Required]
        public string Md5 { get; set; }

        [DisplayName("路径")]
        [StringLength(255)]
        [Required]
        public string Src { get; set; }

        public DateTime? CreationTime { get; set; }
        public Guid? CreatorId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [DisplayName("是否删除")]
        [Required(ErrorMessage = "是否删除不能为空")]
        public bool IsDeleted { get; set; } = false;
    }
}
