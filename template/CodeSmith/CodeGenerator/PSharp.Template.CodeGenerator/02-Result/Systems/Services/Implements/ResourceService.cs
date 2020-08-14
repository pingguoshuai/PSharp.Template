using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications.Trees;
using PSharp.Template.UnitOfWork;
using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;

namespace PSharp.Template.Systems.Services.Implements {
    /// <summary>
    /// 身份资源服务
    /// </summary>
    public class ResourceService : TreeServiceBase<Resource, ResourceDto, ResourceQuery>, IResourceService {
        /// <summary>
        /// 初始化身份资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="resourceRepository">身份资源仓储</param>
        public ResourceService( IDefaultUnitOfWork unitOfWork, IResourceRepository resourceRepository )
            : base( unitOfWork, resourceRepository ) {
            ResourceRepository = resourceRepository;
        }
        
        /// <summary>
        /// 身份资源仓储
        /// </summary>
        public IResourceRepository ResourceRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Resource> CreateQuery( ResourceQuery param ) {
            return new Query<Resource>( param );
        }
    }
}