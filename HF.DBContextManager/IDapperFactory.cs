namespace HF.DBContextManager
{

    /// <summary>
    ///  操作接口
    /// </summary>
    public interface IDapperFactory
    {
        DapperClient CreateClient(string name);
    }
}
