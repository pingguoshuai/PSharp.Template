using System.ComponentModel.DataAnnotations.Schema;
using PSharp.Template.Core.Encryptors;
using Util;
using Util.Security.Encryptors;

namespace PSharp.Template.Systems.Domains.Models {
    /// <summary>
    /// 
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// 加密器
        /// </summary>
        [NotMapped]
        public IEncryptor Encryptor { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            base.Init();
            InitUserName();
        }

        /// <summary>
        /// 初始化用户名
        /// </summary>
        private void InitUserName()
        {
            if (UserName.IsEmpty() == false)
                return;
            if (PhoneNumber.IsEmpty() == false)
            {
                UserName = PhoneNumber;
                return;
            }
            if (Email.IsEmpty() == false)
                UserName = Email;
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="storeOriginalPassword">是否存储原始密码</param>
        public void SetPassword(string password, bool? storeOriginalPassword)
        {
            if (storeOriginalPassword.SafeValue())
            {
                Password = GetEncryptor().Encrypt(password);
                return;
            }
            Password = null;
        }

        /// <summary>
        /// 获取加密器
        /// </summary>
        protected virtual IEncryptor GetEncryptor()
        {
            return Encryptor ?? new PasswordEncryptor();
        }
    }
}