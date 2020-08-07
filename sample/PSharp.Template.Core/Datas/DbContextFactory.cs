using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PSharp.Template.Core.Dependency;
using Util.Datas.Ef.Core;
using Util.Datas.UnitOfWorks;
using Util.Helpers;

namespace PSharp.Template.Core.Datas
{
    public class DbContextFactory : IISingletonDependency
    {
        private readonly List<string> _readConn;

        public DbContextFactory(IConfiguration configuration)
        {
            _readConn = configuration.GetSection("Slave").GetChildren().Select(t => t.Value).ToList();
        }

        public void SetConnectionString(IUnitOfWork unitOfWork)
        {
            if (!_readConn.Any()) return;

            var method = Web.HttpContext?.Request.Method;
            if (!string.IsNullOrEmpty(method))
            {
                if (method.Equals("get", StringComparison.OrdinalIgnoreCase))
                {
                    //随机
                    //轮询
                    //权重
                    int index = new System.Random().Next(0, _readConn.Count);
                    ((UnitOfWorkBase) unitOfWork).Database.GetDbConnection().ConnectionString = _readConn[index];
                }
            }
        }
    }
}
