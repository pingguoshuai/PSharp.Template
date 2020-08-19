using System;
using System.ComponentModel.DataAnnotations;
using Util.Ui.Data;

namespace PSharp.Template.Common.Services.Dtos {
    /// <summary>
    /// 行政区划数据传输对象
    /// </summary>
    public class AreaDto : TreeDto<AreaDto> {
        /// <summary>
        /// Version
        /// </summary>
        [Display( Name = "Version" )]
        public Byte[] Version { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength( 100 )]
        [Display( Name = "名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 区域代码
        /// </summary>
        [Required(ErrorMessage = "区域代码不能为空")]
        [StringLength( 50 )]
        [Display( Name = "区域代码" )]
        public string Code { get; set; }
        /// <summary>
        /// 拼音
        /// </summary>
        [StringLength( 400 )]
        [Display( Name = "拼音" )]
        public string Pinyin { get; set; }
        /// <summary>
        /// 简拼
        /// </summary>
        [Required(ErrorMessage = "简拼不能为空")]
        [StringLength( 200 )]
        [Display( Name = "简拼" )]
        public string Jianpin { get; set; }
        /// <summary>
        /// 区号
        /// </summary>
        [StringLength( 20 )]
        [Display( Name = "区号" )]
        public string AreaCode { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        [StringLength( 6 )]
        [Display( Name = "邮编" )]
        public string ZipCode { get; set; }
        /// <summary>
        /// 精度
        /// </summary>
        [StringLength( 20 )]
        [Display( Name = "精度" )]
        public string Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        [StringLength( 20 )]
        [Display( Name = "纬度" )]
        public string Latitude { get; set; }
    }
}