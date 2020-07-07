using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Util.Domains;
using Util.Domains.Auditing;

namespace PSharp.Template.Common.Domains.Models
{
    [Table("Common.DicType")]
    [Description("字典类型")]
    public partial class DicType : AggregateRoot<DicType>, ICreationAudited, IModificationAudited, IDelete
    {
        public DicType() : base(Guid.Empty)
        {
        }

        public DicType(Guid id) : base(id)
        {
        }

        [DisplayName("类型名称")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [DisplayName("类型代码")]
        [StringLength(50)]
        [Required]
        public string Code { get; set; }

        [DisplayName("字典类型状态")] 
        public bool Status { get; set; } = true;

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
