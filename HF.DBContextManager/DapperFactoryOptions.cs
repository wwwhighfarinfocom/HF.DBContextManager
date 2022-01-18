using System;
using System.Collections.Generic;

namespace HF.DBContextManager
{
    public class DapperFactoryOptions
    {
        public IList<Action<ConnectionConfig>> DapperActions { get; } = new List<Action<ConnectionConfig>>();
    }
}
