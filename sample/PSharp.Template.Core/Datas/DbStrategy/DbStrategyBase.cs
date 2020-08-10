using System.Collections.Generic;
using PSharp.Template.Core.Helper;
using PSharp.Template.Core.Options;

namespace PSharp.Template.Core.Datas.DbStrategy
{
    public interface IDbStrategy
    {
        string GetConnectionString();
    }

    public abstract class DbStrategyBase : IDbStrategy
    {
        protected readonly List<string> ReadConn;

        public DbStrategyBase()
        {
            var dbOptions = ConfigHelper.Get<DbOptions>();
            ReadConn = dbOptions.SlaveList;
        }

        public abstract string GetConnectionString();
    }
}
