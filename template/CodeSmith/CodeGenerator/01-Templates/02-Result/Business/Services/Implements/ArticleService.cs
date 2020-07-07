using System;
using Util;
using Util.Maps;
using Util.Domains.Repositories;
using Util.Datas.Queries;
using Util.Applications;
using PSharp.Template.UnitOfWork;
using PSharp.Template.Business.Domains.Models;
using PSharp.Template.Business.Domains.Repositories;
using PSharp.Template.Business.Services.Dtos;
using PSharp.Template.Business.Services.Queries;
using PSharp.Template.Business.Services.Abstractions;
using PSharp.Template.Business.Services.Dtos.Requests;

namespace PSharp.Template.Business.Services.Implements {
    /// <summary>
    /// 文章服务
    /// </summary>
    public class ArticleService : CrudServiceBase<Article, ArticleDto, UpdateArticleRequest, CreateArticleRequest, UpdateArticleRequest, ArticleQuery,Guid>, IArticleService {
        private readonly IArticleRepository _articleRepository;
        
        /// <summary>
        /// 初始化文章服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="articleRepository">文章仓储</param>
        public ArticleService( IDefaultUnitOfWork unitOfWork, IArticleRepository articleRepository )
            : base( unitOfWork, articleRepository ) {
            _articleRepository = articleRepository;
        }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<Article> CreateQuery( ArticleQuery param ) {
            return new Query<Article>( param );
        }

        protected override Article ToEntityFromUpdateRequest(UpdateArticleRequest request)
        {
            var oldEntity = FindOldEntity(request.Id.ToGuid());
            if (oldEntity == null)
            {
                return base.ToEntityFromUpdateRequest(request);
            }

            request.MapTo(oldEntity);
            return oldEntity;
        }
    }
}