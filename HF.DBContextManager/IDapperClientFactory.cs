namespace HF.DBContextManager
{
    public interface IDapperClientFactory
    {
        DapperClient GetClient(string name);
    }
}
