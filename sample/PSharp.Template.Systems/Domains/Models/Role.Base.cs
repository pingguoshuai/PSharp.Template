﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Util.Domains;
using Util.Domains.Auditing;
using Util.Domains.Trees;

namespace PSharp.Template.Systems.Domains.Models
{
    [Table("Systems.Role")]
    [Description("角色")]
    public partial class Role : TreeEntityBase<Role>, IDelete, IAudited
    {
        /// <summary>
        /// 初始化角色
        /// </summary>
        public Role()
            : this(Guid.Empty, "", 0)
        {
        }

        /// <summary>
        /// 初始化角色
        /// </summary>
        /// <param name="id">角色标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">层级</param>
        public Role(Guid id, string path, int level)
            : base(id, path, level)
        {
        }

        /// <summary>
        /// 角色编码
        /// </summary>
        [Required(ErrorMessage = "角色编码不能为空")]
        [StringLength(256)]
        public string Code { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [DisplayName("角色名称")]
        [Required(ErrorMessage = "角色名称不能为空")]
        [StringLength(256)]
        public string Name { get; set; }
        /// <summary>
        /// 标准化角色名称
        /// </summary>
        [Required(ErrorMessage = "标准化角色名称不能为空")]
        [StringLength(256)]
        public string NormalizedName { get; set; }
        /// <summary>
        /// 角色类型
        /// </summary>
        [Required(ErrorMessage = "角色类型不能为空")]
        [StringLength(80)]
        public string Type { get; set; }
        /// <summary>
        /// 管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(500)]
        public string Remark { get; set; }
        /// <summary>
        /// 拼音简码
        /// </summary>
        [StringLength(200)]
        public string PinYin { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        [StringLength(256)]
        public string Sign { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人标识
        /// </summary>
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人标识
        /// </summary>
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }


        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions()
        {
            AddDescription(t => t.Id);
            AddDescription(t => t.Code);
            AddDescription(t => t.Name);
            AddDescription(t => t.NormalizedName);
            AddDescription(t => t.Type);
            AddDescription(t => t.IsAdmin);
            AddDescription(t => t.ParentId);
            AddDescription(t => t.Path);
            AddDescription(t => t.Level);
            AddDescription(t => t.SortId);
            AddDescription(t => t.Enabled);
            AddDescription(t => t.PinYin);
            AddDescription(t => t.Sign);
            AddDescription(t => t.CreationTime);
            AddDescription(t => t.CreatorId);
            AddDescription(t => t.LastModificationTime);
            AddDescription(t => t.LastModifierId);
        }
    }
}
