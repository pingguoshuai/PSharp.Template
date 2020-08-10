namespace PSharp.Template.Core.Datas.DbStrategy
{
    /// <summary>
    /// 轮询策略
    /// </summary>
    public class PollingStrategy : DbStrategy, IDbStrategy
    {
        private int _currentIndex = -1;

        public override string GetConnectionString()
        {
            _currentIndex++;
            if (_currentIndex >= ReadConn.Count)
                _currentIndex = 0;
            return ReadConn[_currentIndex];
        }
    }
}
