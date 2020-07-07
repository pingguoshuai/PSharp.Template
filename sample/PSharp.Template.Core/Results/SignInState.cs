using System;
using System.Collections.Generic;
using System.Text;

namespace PSharp.Template.Core.Results
{
    public enum SignInState
    {
        /// <summary>
        /// 登录成功
        /// </summary>
        Succeeded,
        /// <summary>
        /// 失败
        /// </summary>
        Failed,
        /// <summary>
        /// 需要两步认证
        /// </summary>
        TwoFactor
    }
}
