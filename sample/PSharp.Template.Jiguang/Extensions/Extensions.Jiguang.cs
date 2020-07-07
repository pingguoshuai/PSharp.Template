using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using PSharp.Template.Jiguang.Options;
using Microsoft.Extensions.Configuration;

namespace PSharp.Template.Jiguang.Extensions
{
    public static class Extensions
    {
        public static void AddJiguangMessage(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<JMessageOptions>(configuration.GetSection("JMessageOptions"));

            var jmessageOption = configuration.GetSection("JMessageOptions").Get<JMessageOptions>();
            services.AddScoped<JMessageClient>(t => new JMessageClient(jmessageOption.AppKey, jmessageOption.MasterSecret));
        }
    }
}
