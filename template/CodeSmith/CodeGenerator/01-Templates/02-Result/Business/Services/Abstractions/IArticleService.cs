using Util.Applications;
using PSharp.Template.Business.Services.Dtos;
using PSharp.Template.Business.Services.Dtos.Requests;
using PSharp.Template.Business.Services.Queries;

namespace PSharp.Template.Business.Services.Abstractions {
    /// <summary>
    /// 文章服务
    /// </summary>
    public interface IArticleService : ICrudService<ArticleDto, UpdateArticleRequest, CreateArticleRequest, UpdateArticleRequest, ArticleQuery> {
    }
}