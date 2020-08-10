using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Util.Dependency;

namespace PSharp.Template.Core.Datas.DbStrategy
{
    public interface IDbStrategy
    {
        string GetConnectionString();
    }

    public abstract class DbStrategy
    {
        protected readonly List<string> ReadConn;

        public DbStrategy(IConfiguration configuration)
        {
            ReadConn = configuration.GetSection("Slave").GetChildren().Select(t => t.Value).ToList();
        }
    }
}
