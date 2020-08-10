using System;
using Microsoft.Extensions.Configuration;

namespace PSharp.Template.Core.Datas.DbStrategy
{
    /// <summary>
    /// 随机策略
    /// </summary>
    public class RandomStrategy : DbStrategy, IDbStrategy
    {
        public RandomStrategy(IConfiguration configuration) : base(configuration)
        {
        }

        public string GetConnectionString()
        {
            int index = new Random().Next(0, ReadConn.Count);
            return ReadConn[index];
        }
    }
}
