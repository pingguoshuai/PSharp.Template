using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PSharp.Template.Systems.Domains.Models;
using PSharp.Template.Systems.Domains.Repositories;
using PSharp.Template.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Util;
using Util.Datas.Ef.Core;

namespace PSharp.Template.Systems.Datas.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository, IUserPasswordStore<User>,
        IUserSecurityStampStore<User>, IUserLockoutStore<User>, IUserEmailStore<User>, IUserPhoneNumberStore<User>
    {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public UserRepository( IDefaultUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }

        /// <summary>
        /// 获取用户编号
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.Id.SafeString());
        }

        /// <summary>
        /// 验证用户
        /// </summary>
        private void ValidateUser(User user, CancellationToken cancellationToken)
        {
            user.CheckNull(nameof(user));
            cancellationToken.ThrowIfCancellationRequested();
        }

        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.UserName);
        }

        /// <summary>
        /// 设置用户名
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.UserName = userName;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取标准化用户名
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.NormalizedUserName);
        }

        /// <summary>
        /// 设置标准化用户名
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="normalizedName">标准化用户名</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            Add(user);
            return Task.FromResult(IdentityResult.Success);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            await UpdateAsync(user);
            return IdentityResult.Success;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            await RemoveAsync(user, cancellationToken);
            return IdentityResult.Success;
        }

        /// <summary>
        /// 根据标识查找
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return FindAsync(userId.ToGuid(), cancellationToken);
        }

        /// <summary>
        /// 通过用户名查找
        /// </summary>
        /// <param name="normalizedUserName">标准化用户名</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return SingleAsync(t => t.NormalizedUserName == normalizedUserName, cancellationToken);
        }

        /// <summary>
        /// 设置密码散列
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="passwordHash">密码散列</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取密码散列
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.PasswordHash);
        }

        /// <summary>
        /// 是否设置密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.PasswordHash.IsEmpty() == false);
        }

        /// <summary>
        /// 设置安全戳
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="stamp">安全戳</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task SetSecurityStampAsync(User user, string stamp, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            if (string.IsNullOrWhiteSpace(stamp))
                throw new ArgumentNullException(nameof(stamp));
            user.SecurityStamp = stamp;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取安全戳
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<string> GetSecurityStampAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.SecurityStamp);
        }

        /// <summary>
        /// 获取锁定结束日期
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<DateTimeOffset?> GetLockoutEndDateAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.LockoutEnd);
        }

        /// <summary>
        /// 设置锁定结束日期
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="lockoutEnd">锁定结束日期</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.LockoutEnd = lockoutEnd;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 增加访问失败次数
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<int> IncrementAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.AccessFailedCount = user.AccessFailedCount.SafeValue() + 1;
            return Task.FromResult(user.AccessFailedCount.SafeValue());
        }

        /// <summary>
        /// 重置访问失败次数
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task ResetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.AccessFailedCount = 0;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取登录失败次数
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<int> GetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.AccessFailedCount.SafeValue());
        }

        /// <summary>
        /// 获取锁定启用状态
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<bool> GetLockoutEnabledAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.LockoutEnabled);
        }

        /// <summary>
        /// 设置锁定启用状态
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="enabled">是否启用锁定</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task SetLockoutEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.LockoutEnabled = enabled;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 设置电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="email">电子邮件</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.Email = email;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.Email);
        }

        /// <summary>
        /// 获取电子邮件确认状态
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.EmailConfirmed);
        }

        /// <summary>
        /// 确认电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="confirmed">是否确认</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.EmailConfirmed = confirmed;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 通过电子邮件查找
        /// </summary>
        /// <param name="normalizedEmail">标准化电子邮件</param>
        /// <param name="cancellationToken">取消令牌</param>
        public async Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await SingleAsync(u => u.NormalizedEmail == normalizedEmail, cancellationToken);
        }

        /// <summary>
        /// 获取标准化电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.NormalizedEmail);
        }

        /// <summary>
        /// 设置标准化电子邮件
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="normalizedEmail">标准化电子邮件</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.NormalizedEmail = normalizedEmail;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 设置手机号
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="phoneNumber">手机号</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.PhoneNumber = phoneNumber;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取手机号
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<string> GetPhoneNumberAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.PhoneNumber);
        }

        /// <summary>
        /// 获取手机号确认状态
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        /// <summary>
        /// 设置手机号确认状态
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="confirmed">是否确认</param>
        /// <param name="cancellationToken">取消令牌</param>
        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            ValidateUser(user, cancellationToken);
            user.PhoneNumberConfirmed = confirmed;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 过滤角色
        /// </summary>
        /// <param name="queryable">查询对象</param>
        /// <param name="roleId">角色标识</param>
        /// <param name="except">是否排除该角色的用户列表</param>
        public IQueryable<User> FilterByRole(IQueryable<User> queryable, Guid roleId, bool except = false)
        {
            if (roleId.IsEmpty())
                return queryable;
            var selectedUsers = from user in queryable
                                join userRole in UnitOfWork.Set<UserRole>() on user.Id equals userRole.UserId
                                where userRole.RoleId == roleId
                                select user;
            if (except)
                return queryable.Except(selectedUsers);
            return selectedUsers;
        }

        /// <summary>
        /// 用户指定角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public async Task AddRolesToUserAsync(Guid userId, List<Guid> roleIds)
        {
            if (userId.IsEmpty())
                return;
            var oldRoleIds = await GetRoleIdsAsync(userId);
            var result = roleIds.Compare(oldRoleIds);

            await UnitOfWork.Set<UserRole>().AddRangeAsync(ToUserRoles(userId, result.CreateList));
            UnitOfWork.Set<UserRole>().RemoveRange(ToUserRoles(userId, result.DeleteList));
        }

        /// <summary>
        /// 转换为UserRole实体列表
        /// </summary>
        private List<UserRole> ToUserRoles(Guid userId, List<Guid> roleIds)
        {
            return roleIds.Select(roleId => ToUserRole(userId, roleId)).ToList();
        }

        private UserRole ToUserRole(Guid userId, Guid roleId)
        {
            var result = new UserRole(userId, roleId);

            return result;
        }

        /// <summary>
        /// 获取角色标识列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<Guid>> GetRoleIdsAsync(Guid userId)
        {
            var queryable = UnitOfWork.Set<UserRole>().Where(t=>t.UserId == userId).Select(t => t.RoleId);

            return await queryable.ToListAsync();
        }
    }
}