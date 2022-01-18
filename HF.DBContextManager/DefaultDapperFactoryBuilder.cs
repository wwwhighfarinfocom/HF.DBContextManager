using Microsoft.Extensions.DependencyInjection;

namespace HF.DBContextManager
{
    internal class DefaultDapperFactoryBuilder : IDapperFactoryBuilder
    {
        public DefaultDapperFactoryBuilder(IServiceCollection services, string name)
        {
            Services = services;
            Name = name;
        }

        public string Name { get; }

        public IServiceCollection Services { get; }
    }
}
