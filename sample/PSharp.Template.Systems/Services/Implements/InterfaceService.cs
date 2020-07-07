using System.Collections.Generic;
using PSharp.Template.Systems.AuthHelper;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Abstractions;

namespace PSharp.Template.Systems.Services.Implements {
    /// <summary>
    /// 接口服务
    /// </summary>
    public class InterfaceService : IInterfaceService {
        private readonly InterfaceCollection _interfaceCollection;

        /// <summary>
        /// 初始化接口服务
        /// </summary>
        /// <param name="interfaceCollection"></param>
        public InterfaceService(InterfaceCollection interfaceCollection)
        {
            _interfaceCollection = interfaceCollection;
        }

        public List<InterfaceDto> GetTree()
        {
            return _interfaceCollection.Tree;
        }

        public List<InterfaceDto> GetList()
        {
            return _interfaceCollection.List;
        }
    }
}