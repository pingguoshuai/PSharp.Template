using Util.Datas.Sql;

namespace PSharp.Template.Systems.Domains.Models {
    /// <summary>
    /// 
    /// </summary>
    public partial class Permission
    {
        [Ignore]
        public Resource Resource { get; set; }
    }
}