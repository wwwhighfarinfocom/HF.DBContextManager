using Microsoft.Extensions.DependencyInjection;

namespace HF.DBContextManager
{
    public interface IDapperFactoryBuilder
    {
        string Name { get; }

        IServiceCollection Services { get; }
    }
}
