using System;
using System.Collections.Generic;
using System.Text;

namespace PSharp.Template.Core.Options
{
    public class DbOptions
    {
        public string Strategy { get; set; }
        public List<string> SlaveList { get; set; }
    }

    public enum DbStrategyEnum
    {
        Polling = 1,
        Random = 2,
        Weight = 3
    }
}
