using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PSharp.Template.Core.Dependency;
using PSharp.Template.Systems.Domains.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace PSharp.Template.Systems.Domains.Services.Implements
{
    public class IdentityUserManager : AspNetUserManager<User>, IIScopeDependency
    {
        public IdentityUserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger) : base(store,
            optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services,
            logger)
        {
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="newPassword">新密码</param>
        public async Task<IdentityResult> UpdatePasswordAsync(User user, string newPassword)
        {
            ThrowIfDisposed();
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            var result = await UpdatePasswordHash(user, newPassword, true);
            if (!result.Succeeded)
                return result;
            return await UpdateUserAsync(user);
        }
    }
}
