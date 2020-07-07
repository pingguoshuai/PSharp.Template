using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using PSharp.Template.Systems.Domains.Enums;

namespace PSharp.Template.Systems.Domains.Models {
    /// <summary>
    /// 
    /// </summary>
    public partial class Application {

        /// <summary>
        /// 应用程序类型
        /// </summary>
        [DisplayName("应用程序类型")]
        [NotMapped]
        public ApplicationType ApplicationType { get; set; }

        /// <summary>
        /// 是否客户端
        /// </summary>
        [DisplayName("是否客户端")]
        [NotMapped]
        public bool IsClient { get; set; }
        ///// <summary>
        ///// 客户端
        ///// </summary>
        //public Client Client { get; set; }
    }
}