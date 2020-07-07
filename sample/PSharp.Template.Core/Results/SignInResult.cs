using System;
using System.Collections.Generic;
using System.Text;

namespace PSharp.Template.Core.Results
{
    /// <summary>
    /// 登录结果
    /// </summary>
    public class SignInResult
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public SignInResult()
        {
            State = SignInState.Failed;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="state">登录状态</param>
        /// <param name="user">用户标识</param>
        /// <param name="message">消息</param>
        public SignInResult(SignInState state, dynamic user, string message = null)
        {
            State = state;
            Data = user;
            Message = message;
        }

        /// <summary>
        /// 登录状态
        /// </summary>
        public SignInState State { get; set; }

        /// <summary>
        /// 用户标识
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
    }
}
