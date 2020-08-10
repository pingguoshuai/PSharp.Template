using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace PSharp.Template.Core.Datas.DbStrategy
{
    public class PollingStrategy : DbStrategy, IDbStrategy
    {
        private int _currentIndex = -1;

        public PollingStrategy(IConfiguration configuration) : base(configuration)
        {

        }

        public string GetConnectionString()
        {
            _currentIndex++;
            if (_currentIndex >= ReadConn.Count)
                _currentIndex = 0;
            return ReadConn[_currentIndex];
        }
    }
}
