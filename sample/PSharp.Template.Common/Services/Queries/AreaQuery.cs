using System.ComponentModel.DataAnnotations;
using Util.Applications.Trees;
using Util.Datas.Queries.Trees;

namespace PSharp.Template.Common.Services.Queries {
    /// <summary>
    /// 行政区划查询参数
    /// </summary>
    public class AreaQuery : TreeQueryParameter<int?> {

        private string _name = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name="名称")]
        public string Name {
            get => _name == null ? string.Empty : _name.Trim();
            set => _name = value;
        }
        
        private string _code = string.Empty;
        /// <summary>
        /// 区域代码
        /// </summary>
        [Display(Name="区域代码")]
        public string Code {
            get => _code == null ? string.Empty : _code.Trim();
            set => _code = value;
        }
        
        private string _pinyin = string.Empty;
        /// <summary>
        /// 拼音
        /// </summary>
        [Display(Name="拼音")]
        public string Pinyin {
            get => _pinyin == null ? string.Empty : _pinyin.Trim();
            set => _pinyin = value;
        }
        
        private string _jianpin = string.Empty;
        /// <summary>
        /// 简拼
        /// </summary>
        [Display(Name="简拼")]
        public string Jianpin {
            get => _jianpin == null ? string.Empty : _jianpin.Trim();
            set => _jianpin = value;
        }

        /// <summary>
        /// 加载操作：1、首次加载  2、加载子节点
        /// </summary>
        public LoadOperation Operation { get; set; } = LoadOperation.FirstLoad;

        ///// <summary>
        ///// 操作类型：子节点传“loadchild”
        ///// </summary>
        //public string Operation { get; set; }
    }
}