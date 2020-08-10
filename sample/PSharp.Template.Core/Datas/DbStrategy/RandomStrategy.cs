using System;

namespace PSharp.Template.Core.Datas.DbStrategy
{
    /// <summary>
    /// 随机策略
    /// </summary>
    public class RandomStrategy : DbStrategyBase
    {
        public override string GetConnectionString()
        {
            int index = new Random().Next(0, ReadConn.Count);
            return ReadConn[index];
        }
    }
}
