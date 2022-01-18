using System.Collections.Generic;

namespace HF.DBContextManager
{
    public class DapperClientListOptions
    {
        public Dictionary<string, DapperClient> DapperDictionary { get; set; } =new Dictionary<string, DapperClient>();
    }
}
