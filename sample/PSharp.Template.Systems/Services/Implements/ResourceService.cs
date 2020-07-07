using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using PSharp.Template.Systems.Services.Dtos.Extensions;
using PSharp.Template.Systems.Services.Dtos.Requests;

namespace PSharp.Template.Systems.Services.Implements {
    /// <summary>
    /// 服务
    /// </summary>
    public class ResourceService : TreeServiceBase<Resource, ResourceDto, ResourceQuery>, IResourceService {
        private readonly IDefaultUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;

        /// <summary>
        /// 初始化服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="resourceRepository">仓储</param>
        /// <param name="roleRepository"></param>
        public ResourceService( IDefaultUnitOfWork unitOfWork, IResourceRepository resourceRepository,
            IRoleRepository roleRepository)
            : base( unitOfWork, resourceRepository )
        {
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
            ResourceRepository = resourceRepository;
        }
        
        /// <summary>
        /// 仓储
        /// </summary>
        public IResourceRepository ResourceRepository { get; set; }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<Resource> Filter(IQueryable<Resource> queryable, ResourceQuery parameter)
        {
            return base.Filter(queryable, parameter);
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Resource> CreateQuery( ResourceQuery param )
        {
            param.ApplicationId.CheckNull(nameof(param.ApplicationId));
            var query = new Query<Resource>(param);

            query.WhereIf(t => t.ApplicationId.Equals(param.ApplicationId), param.ApplicationId.HasValue);
            return query;
        }

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ResourceDto ToDto(Resource entity)
        {
            return entity.ToDto();
        }

        /// <summary>
        /// 创建资源
        /// </summary>
        /// <param name="request">创建资源参数</param>
        public async Task<Guid> CreateAsync(CreateResourceRequest request)
        {
            var module = request.MapTo<Resource>();
            module.CheckNull(nameof(module));
            module.Init();
            var parent = await ResourceRepository.FindAsync(module.ParentId);
            module.InitPath(parent);
            //module.SortId = await ModuleRepository.GenerateSortIdAsync(module.ApplicationId.SafeValue(), module.ParentId);
            await ResourceRepository.AddAsync(module);
            await _unitOfWork.CommitAsync();
            return module.Id;
        }

        /// <summary>
        /// 修改资源
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateAsync(ResourceDto request)
        {
            var resource = await ResourceRepository.FindAsync(request.Id.ToGuid());
            request.MapTo(resource);
            await ResourceRepository.UpdatePathAsync(resource);
            await ResourceRepository.UpdateAsync(resource);
            await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        public async Task<List<ResourceDto>> GetMenuAsync()
        {
            var userId = Session.UserId;
            //var roleIds = Session.GetRoleIds();
            var roleIds = await _roleRepository.GetRoleIdsAsync(userId.ToGuid());
            var menus = await ResourceRepository.GetMenusAsync(roleIds);
            return menus.Select(ToDto).ToList();
        }
    }
}