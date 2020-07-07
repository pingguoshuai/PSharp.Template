using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Util.Domains;
using Util.Domains.Auditing;

namespace PSharp.Template.Common.Domains.Models
{
    [Table("Common.DicInfo")]
    [Description("数据字典")]
    public partial class DicInfo : AggregateRoot<DicInfo>, ICreationAudited, IModificationAudited, IDelete
    {
        public DicInfo() : base(Guid.Empty)
        {
        }
        public DicInfo(Guid id) : base(id)
        {
        }

        public Guid DicTypeId { get; set; }
        public DicType DicType { get; set; }

        [DisplayName("字典名称")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [DisplayName("字典值")]
        [StringLength(50)]
        [Required]
        public string Value { get; set; }

        [DisplayName("排序")]
        public int Sort { get; set; } = 0;

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
