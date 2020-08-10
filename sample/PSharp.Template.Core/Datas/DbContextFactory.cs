using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PSharp.Template.Core.Datas.DbStrategy;
using PSharp.Template.Core.Dependency;
using PSharp.Template.Core.Options;
using Util.Datas.Ef.Core;
using Util.Datas.UnitOfWorks;
using Util.Helpers;

namespace PSharp.Template.Core.Datas
{
    public class DbContextFactory : IISingletonDependency
    {
        private readonly IDbStrategy _dbStrategy;
        private readonly List<string> _readConn;

        public DbContextFactory(IOptions<DbOptions> dbOptions, IDbStrategy dbStrategy)
        {
            _dbStrategy = dbStrategy;
            _readConn = dbOptions.Value.SlaveList.ToList();
        }

        public void SetConnectionString(IUnitOfWork unitOfWork)
        {
            if (!_readConn.Any()) return;

            var method = Web.HttpContext?.Request.Method;
            if (!string.IsNullOrEmpty(method))
            {
                if (method.Equals("get", StringComparison.OrdinalIgnoreCase))
                {
                    ((UnitOfWorkBase)unitOfWork).Database.GetDbConnection().ConnectionString = _dbStrategy.GetConnectionString();
                }
            }
        }
    }
}
