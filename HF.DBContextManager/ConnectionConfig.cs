namespace HF.DBContextManager
{

    /// <summary>
    ///  数据库操作参数
    /// </summary>
    public class ConnectionConfig
    {
        public string ConnectionString { get; set; }
        public DBStoreType DbType { get; set; }
    }
}
