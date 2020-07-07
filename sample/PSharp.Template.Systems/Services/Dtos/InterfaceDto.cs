using System.ComponentModel.DataAnnotations;
using Util.Ui.Data;

namespace PSharp.Template.Systems.Services.Dtos {
    /// <summary>
    /// 接口参数
    /// </summary>
    public class InterfaceDto : TreeDto<InterfaceDto>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        [StringLength( 250 )]
        [Display( Name = "名称" )]
        public string Name { get; set; }
        /// <summary>
        /// 模块编码
        /// </summary>
        [StringLength( 50 )]
        [Display( Name = "模块编码" )]
        public string ModuleCode { get; set; }
        /// <summary>
        /// 控制器
        /// </summary>
        [Required(ErrorMessage = "控制器不能为空")]
        [StringLength( 50 )]
        [Display( Name = "控制器" )]
        public string Contorller { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        [Required(ErrorMessage = "操作不能为空")]
        [StringLength( 50 )]
        [Display( Name = "操作" )]
        public string Action { get; set; }
        /// <summary>
        /// 路由
        /// </summary>
        [StringLength(50)]
        [Display(Name = "路由")]
        public string Route { get; set; }
        /// <summary>
        /// 请求方式
        /// </summary>
        [Required(ErrorMessage = "请求方式不能为空")]
        [StringLength(10)]
        [Display( Name = "请求方式" )]
        public string HttpMethod { get; set; }
        /// <summary>
        /// 唯一编码
        /// </summary>
        [Required(ErrorMessage = "唯一编码不能为空")]
        [StringLength( 200 )]
        [Display( Name = "唯一编码" )]
        public string Code { get; set; }
    }
}