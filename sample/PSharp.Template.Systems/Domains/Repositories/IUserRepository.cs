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
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// 用户指定角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        Task AddRolesToUserAsync(Guid userId, List<Guid> roleIds);
    }
}