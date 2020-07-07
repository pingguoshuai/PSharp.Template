using System;
using System.Collections.Generic;
using System.Text;
using Util.Security.Encryptors;

namespace PSharp.Template.Core.Encryptors
{
    /// <summary>
    /// 密码加密器
    /// </summary>
    public class PasswordEncryptor : IEncryptor
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data">原始数据</param>
        public string Encrypt(string data)
        {
            return Util.Helpers.Encrypt.AesEncrypt(data);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data">已加密数据</param>
        public string Decrypt(string data)
        {
            return Util.Helpers.Encrypt.AesDecrypt(data);
        }
    }
}
