using Microsoft.Extensions.Configuration;
using System.IO;

namespace PSharp.Template.Core.Helper
{
    public static class ConfigHelper
    {
        public static IConfiguration Configuration { get; set; }

        static ConfigHelper()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
        
        /// <summary>
        /// 根据配置文件和Key获得对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : class, new()
        {
            var key = typeof(T).Name;
            if (string.IsNullOrEmpty(key))
                return default(T);

            var  options = Configuration.GetSection(key).Get<T>();
            return options;
        }
    }
}
