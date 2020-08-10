using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using PSharp.Template.UnitOfWork;
using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.Systems.Services.Dtos;
using PSharp.Template.Systems.Services.Queries;
using PSharp.Template.Systems.Services.Abstractions;
using PSharp.Template.Systems.Services.Dtos.Requests;
using Microsoft.EntityFrameworkCore;
using Util.Exceptions;
using PSharp.Template.Core;

namespace PSharp.Template.Systems.Services.Implements {
    /// <summary>
    /// 服务
    /// </summary>
    public class ApplicationService : CrudServiceBase<Application, ApplicationDto, CreateApplicationRequest, ApplicationQuery,Guid>, IApplicationService {
        /// <summary>
        /// 初始化服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="applicationRepository">仓储</param>
        public ApplicationService( IDefaultUnitOfWork unitOfWork, IApplicationRepository applicationRepository )
            : base( unitOfWork, applicationRepository ) {
            ApplicationRepository = applicationRepository;
        }
        
        /// <summary>
        /// 仓储
        /// </summary>
        public IApplicationRepository ApplicationRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Application> CreateQuery( ApplicationQuery param ) {
            var query = new Query<Application>(param);
            query.OrderBy(t => t.CreationTime);
            return query;
        }

        protected override Application ToEntityFromUpdateRequest(CreateApplicationRequest request)
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
        /// 获取全部
        /// </summary>
        public override async Task<List<ApplicationDto>> GetAllAsync()
        {
            var entities = await ApplicationRepository.Find().OrderBy(t => t.CreationTime).ToListAsync();
            return entities.Select(ToDto).ToList();
        }

        /// <summary>
        /// 验证创建应用程序
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected override async Task CreateBeforeAsync(Application entity)
        {
            entity.CheckNull(nameof(entity));
            if (await ApplicationRepository.CanCreateAsync(entity) == false)
                ThrowCodeRepeatException(entity);
        }

        /// <summary>
        /// 验证修改应用程序
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected override async Task UpdateBeforeAsync(Application entity)
        {
            entity.CheckNull(nameof(entity));
            if (await ApplicationRepository.CanUpdateAsync(entity) == false)
                ThrowCodeRepeatException(entity);
        }

        /// <summary>
        /// 抛出编码重复异常
        /// </summary>
        private void ThrowCodeRepeatException(Application entity)
        {
            throw new Warning(string.Format(DefaultResource.DuplicateApplicationCode, entity.Code));
        }
    }
}