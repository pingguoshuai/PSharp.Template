using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Util.Domains;
using Util.Domains.Trees;
using Util.Domains.Auditing;

namespace PSharp.Template.Common.Domains.Models {
    /// <summary>
    /// 行政区划
    /// </summary>
    [Description( "行政区划" )]
    public partial class Area : TreeEntityBase<Area,int,int?>,IDelete,IAudited {
        /// <summary>
        /// 初始化行政区划
        /// </summary>
        public Area()
            : this( 0, "", 0 ) {
        }

        /// <summary>
        /// 初始化行政区划
        /// </summary>
        /// <param name="id">行政区划标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">层级</param>
        public Area( int id, string path, int level )
            : base( id, path, level ) {
        }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength( 100 )]
        public string Name { get; set; }
        /// <summary>
        /// 区域代码
        /// </summary>
        [Required(ErrorMessage = "区域代码不能为空")]
        [StringLength( 50 )]
        public string Code { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        [StringLength( 400 )]
        public string Pinyin { get; set; }
        /// <summary>
        /// 简拼
        /// </summary>
        [Required(ErrorMessage = "简拼不能为空")]
        [StringLength( 200 )]
        public string Jianpin { get; set; }
        /// <summary>
        /// 区号
        /// </summary>
        [StringLength( 20 )]
        public string AreaCode { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        [StringLength( 6 )]
        public string ZipCode { get; set; }
        /// <summary>
        /// 精度
        /// </summary>
        [StringLength( 20 )]
        public string Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        [StringLength( 20 )]
        public string Latitude { get; set; }
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
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.ParentId );
            AddDescription( t => t.Path );
            AddDescription( t => t.Level );
            AddDescription( t => t.Enabled );
            AddDescription( t => t.SortId );
            AddDescription( t => t.Name );
            AddDescription( t => t.Code );
            AddDescription( t => t.Pinyin );
            AddDescription( t => t.Jianpin );
            AddDescription( t => t.AreaCode );
            AddDescription( t => t.ZipCode );
            AddDescription( t => t.Longitude );
            AddDescription( t => t.Latitude );
            AddDescription( t => t.CreationTime );
            AddDescription( t => t.CreatorId );
            AddDescription( t => t.LastModificationTime );
            AddDescription( t => t.LastModifierId );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( Area other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.ParentId, other.ParentId );
            AddChange( t => t.Path, other.Path );
            AddChange( t => t.Level, other.Level );
            AddChange( t => t.Enabled, other.Enabled );
            AddChange( t => t.SortId, other.SortId );
            AddChange( t => t.Name, other.Name );
            AddChange( t => t.Code, other.Code );
            AddChange( t => t.Pinyin, other.Pinyin );
            AddChange( t => t.Jianpin, other.Jianpin );
            AddChange( t => t.AreaCode, other.AreaCode );
            AddChange( t => t.ZipCode, other.ZipCode );
            AddChange( t => t.Longitude, other.Longitude );
            AddChange( t => t.Latitude, other.Latitude );
            AddChange( t => t.CreationTime, other.CreationTime );
            AddChange( t => t.CreatorId, other.CreatorId );
            AddChange( t => t.LastModificationTime, other.LastModificationTime );
            AddChange( t => t.LastModifierId, other.LastModifierId );
        }
    }
}