using System;
using System.Linq;
using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using PSharp.Template.UnitOfWork;
using PSharp.Template.Common.Domains.Models;
using PSharp.Template.Common.Domains.Repositories;
using PSharp.Template.Common.Services.Dtos;
using PSharp.Template.Common.Services.Queries;
using PSharp.Template.Common.Services.Abstractions;
using PSharp.Template.Common.Services.Dtos.Requests;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using PSharp.Template.Common.Domains.Services.Abstractions;

namespace PSharp.Template.Common.Services.Implements
{
    /// <summary>
    /// 服务
    /// </summary>
    public class DicInfoService : CrudServiceBase<DicInfo, DicInfoDto, CreateDicInfoRequest, DicInfoQuery, Guid>, IDicInfoService
    {
        private readonly IDicInfoManager _dicInfoManager;

        /// <summary>
        /// 初始化服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="dicInfoRepository">仓储</param>
        /// <param name="dicInfoManager"></param>
        public DicInfoService(IDefaultUnitOfWork unitOfWork, IDicInfoRepository dicInfoRepository,IDicInfoManager dicInfoManager)
            : base(unitOfWork, dicInfoRepository)
        {
            _dicInfoManager = dicInfoManager;
            DicInfoRepository = dicInfoRepository;
        }

        /// <summary>
        /// 仓储
        /// </summary>
        public IDicInfoRepository DicInfoRepository { get; set; }

        /// <summary>
        /// 过滤
        /// </summary>
        protected override IQueryable<DicInfo> Filter(IQueryable<DicInfo> queryable, DicInfoQuery parameter)
        {
            return base.Filter(queryable, parameter).Include(t => t.DicType);
        }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<DicInfo> CreateQuery(DicInfoQuery param)
        {
            var query = new Query<DicInfo>(param);
            if (param.Name != String.Empty)
            {
                query.Where(t => t.Name.Contains(param.Name));
            }
            if (param.Value != String.Empty)
            {
                query.Where(t => t.Value.Equals(param.Value));
            }
            if (param.DicTypeId != Guid.Empty && param.DicTypeId != null)
            {
                query.Where(t => t.DicTypeId.Equals(param.DicTypeId.Value));
            }
            if (param.Status != null)
            {
                query.Where(t => t.Status.Equals(param.Status));
            }
            query.OrderBy(t => t.CreationTime, true);
            return query;
        }

        protected override DicInfo ToEntityFromUpdateRequest(CreateDicInfoRequest request)
        {
            var oldEntity = FindOldEntity(request.Id.ToGuid());
            if (oldEntity == null)
            {
                return base.ToEntityFromUpdateRequest(request);
            }

            request.MapTo(oldEntity);
            oldEntity.Version = request.Version;
            return oldEntity;
        }

        /// <summary>
        /// 根据父code 查询列表
        /// </summary>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        public async Task<List<DicInfoDto>> GetListByTypeCode(string typeCode)
        {
            return (await _dicInfoManager.GetListByTypeCode(typeCode)).Select(ToDto).ToList();
        }

        /// <summary>
        /// 根据value 和 父code查询实体
        /// </summary>
        /// <param name="typecode"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<DicInfoDto> GetByCodeAndValue(string typecode, string value)
        {
            return (await _dicInfoManager.GetByCodeAndValue(typecode, value)).MapTo<DicInfoDto>();
        }
    }
}