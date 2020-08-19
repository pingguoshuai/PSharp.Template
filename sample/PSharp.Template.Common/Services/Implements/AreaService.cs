using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications.Trees;
using PSharp.Template.UnitOfWork;
using PSharp.Template.Common.Domains.Models;
using PSharp.Template.Common.Domains.Repositories;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Queries;
using PSharp.Template.Common.Services.Abstractions;
using PSharp.Template.Common.Services.Dtos.Extensions;
using PSharp.Template.Common.Services.Dtos.Requests;
using Util;
using Util.Maps;
using PSharp.Template.Common.Domains.Services.Abstractions;

namespace PSharp.Template.Common.Services.Implements {
    /// <summary>
    /// 行政区划服务
    /// </summary>
    public class AreaService : TreeServiceBase<Area, AreaDto, AreaQuery,int, int?>, IAreaService {
        private readonly IDefaultUnitOfWork _unitOfWork;

        /// <summary>
        /// 初始化行政区划服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="areaRepository">行政区划仓储</param>
        public AreaService( IDefaultUnitOfWork unitOfWork, IAreaRepository areaRepository )
            : base( unitOfWork, areaRepository )
        {
            _unitOfWork = unitOfWork;
            AreaRepository = areaRepository;
        }
        
        /// <summary>
        /// 行政区划仓储
        /// </summary>
        public IAreaRepository AreaRepository { get; set; }
        public IAreaManager AreaManager { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Area> CreateQuery( AreaQuery param ) {
            var query = new Query<Area, int>(param);
            if (param.ParentId.HasValue)
            {
                query.Where(t => t.ParentId.Equals(param.ParentId.Value));
            }
            else
            {
                query.Where(t => t.ParentId.Equals(0));
            }

            query.OrderBy(t => t.Id);
            return query;
        }

        protected override AreaDto ToDto(Area entity)
        {
            return entity.ToDto();
        }

        protected override async Task<List<Area>> GetChildren(AreaQuery parameter)
        {
            return await AreaRepository.FindAllAsync(t => t.ParentId == parameter.ParentId);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        public async Task<int> CreateAsync(CreateAreaRequest request)
        {
            var module = request.MapTo<Area>();
            module.CheckNull(nameof(module));
            module.Init();
            var parent = await AreaRepository.FindAsync(module.ParentId);
            module.InitPath(parent);
            //module.SortId = await ModuleRepository.GenerateSortIdAsync(module.ApplicationId.SafeValue(), module.ParentId);
            await AreaRepository.AddAsync(module);
            await _unitOfWork.CommitAsync();
            return module.Id;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateAsync(UpdateAreaRequest request)
        {
            var resource = await AreaRepository.FindAsync(request.Id.ToGuid());
            request.MapTo(resource);
            await AreaRepository.UpdatePathAsync(resource);
            await AreaRepository.UpdateAsync(resource);
            await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// 根据父id查询列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<List<AreaDto>> GetListByPid(int parentId)
        {
            return (await AreaManager.GetListByPid(parentId)).Select(ToDto).ToList();
        }
    }
}