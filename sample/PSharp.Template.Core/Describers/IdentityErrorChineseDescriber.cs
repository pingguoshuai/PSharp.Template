using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace PSharp.Template.Core.Describers
{
    /// <summary>
    /// Identity中文错误描述
    /// </summary>
    public class IdentityErrorChineseDescriber : IdentityErrorDescriber
    {
        /// <summary>
        /// 密码太短
        /// </summary>
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = string.Format(DefaultResource.PasswordTooShort, length)
            };
        }

        /// <summary>
        /// 密码应包含非字母和数字的特殊字符
        /// </summary>
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = DefaultResource.PasswordRequiresNonAlphanumeric
            };
        }

        /// <summary>
        /// 密码应包含大写字母
        /// </summary>
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = DefaultResource.PasswordRequiresUpper
            };
        }

        /// <summary>
        /// 密码应包含数字
        /// </summary>
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = DefaultResource.PasswordRequiresDigit
            };
        }

        /// <summary>
        /// 密码应包含不重复的字符数
        /// </summary>
        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUniqueChars),
                Description = string.Format(DefaultResource.PasswordRequiresUniqueChars, uniqueChars)
            };
        }

        /// <summary>
        /// 无效用户名
        /// </summary>
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(InvalidUserName),
                Description = string.Format(DefaultResource.InvalidUserName, userName)
            };
        }

        /// <summary>
        /// 用户名重复
        /// </summary>
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = string.Format(DefaultResource.DuplicateUserName, userName)
            };
        }

        /// <summary>
        /// 电子邮件重复
        /// </summary>
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = string.Format(DefaultResource.DuplicateEmail, email)
            };
        }

        /// <summary>
        /// 无效令牌
        /// </summary>
        public override IdentityError InvalidToken()
        {
            return new IdentityError
            {
                Code = nameof(InvalidToken),
                Description = DefaultResource.InvalidToken
            };
        }

        /// <summary>
        /// 密码错误
        /// </summary>
        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Code = nameof(PasswordMismatch),
                Description = DefaultResource.PasswordMismatch
            };
        }

        /// <summary>
        /// 角色名无效
        /// </summary>
        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError
            {
                Code = nameof(InvalidRoleName),
                Description = string.Format(DefaultResource.InvalidRoleName, role)
            };
        }

        /// <summary>
        /// 角色名重复
        /// </summary>
        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateRoleName),
                Description = string.Format(DefaultResource.DuplicateRoleName, role)
            };
        }
    }
}
