using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Util;

namespace PSharp.Template.Core.Helper
{
    public static class Encrypt
    {
        /// <summary>
        /// Md5加密，返回32位结果
        /// </summary>
        /// <param name="value">值</param>
        public static string Md5By32(byte[] value)
        {
            return Md5(value, null, null);
        }

        /// <summary>
        /// Md5加密
        /// </summary>
        private static string Md5(byte[] value, int? startIndex, int? length)
        {
            value.CheckNull(nameof(value));
            var md5 = new MD5CryptoServiceProvider();
            string result;
            try
            {
                var hash = md5.ComputeHash(value);
                result = startIndex == null ? BitConverter.ToString(hash) : BitConverter.ToString(hash, startIndex.SafeValue(), length.SafeValue());
            }
            finally
            {
                md5.Clear();
            }
            return result.Replace("-", "");
        }
    }
}
