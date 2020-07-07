using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Applications;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Dtos.Requests;
using PSharp.Template.Systems.Services.Queries;

namespace PSharp.Template.Systems.Services.Abstractions {
    /// <summary>
    /// 接口服务
    /// </summary>
    public interface IInterfaceService : IService
    {
        /// <summary>
        /// 所有接口tree
        /// </summary>
        /// <returns></returns>
        List<InterfaceDto> GetTree();

        List<InterfaceDto> GetList();
    }
}