using Util.Webs.Controllers;
using PSharp.Template.Business.Services.Dtos;
using PSharp.Template.Business.Services.Queries;
using PSharp.Template.Business.Services.Abstractions;
using PSharp.Template.Business.Services.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace PSharp.Template.Business.Controllers {
    /// <summary>
    /// 文章控制器
    /// </summary>
    [ApiExplorerSettings(GroupName = "Business")]
    public class ArticleController : CrudControllerBase<ArticleDto, CreateArticleRequest, UpdateArticleRequest, ArticleQuery> {
        /// <summary>
        /// 初始化文章控制器
        /// </summary>
        /// <param name="service">文章服务</param>
        public ArticleController( IArticleService service ) : base( service ) {
            ArticleService = service;
        }
        
        /// <summary>
        /// 文章服务
        /// </summary>
        public IArticleService ArticleService { get; }
    }
}