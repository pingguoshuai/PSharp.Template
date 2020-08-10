using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PSharp.Template.Core.Helper;
using PSharp.Template.Core.Options;
using Util.Dependency;

namespace PSharp.Template.Core.Datas.DbStrategy
{
    public interface IDbStrategy
    {
        string GetConnectionString();
    }

    public abstract class DbStrategy : IDbStrategy
    {
        protected readonly List<string> ReadConn;

        public DbStrategy()
        {
            var dbOptions = ConfigHelper.Get<DbOptions>();
            ReadConn = dbOptions.SlaveList;
        }

        public abstract string GetConnectionString();
    }
}
