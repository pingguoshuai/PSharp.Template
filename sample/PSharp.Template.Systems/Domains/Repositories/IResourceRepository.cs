using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Domains.Repositories;
using Util.Domains.Trees;
using PSharp.Template.Systems.Domains.Models;

namespace PSharp.Template.Systems.Domains.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IResourceRepository : ITreeRepository<Resource>
    {
        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="roleIds">角色标识列表</param>
        /// <returns></returns>
        Task<List<Resource>> GetMenusAsync(List<Guid> roleIds);
    }
}
