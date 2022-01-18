using System;
using System.Linq;

using Microsoft.Extensions.Options;

namespace HF.DBContextManager
{

    /// <summary>
    ///  实现接口
    /// </summary>
    public class DefaultDapperFactory : IDapperFactory
    {
        private readonly IServiceProvider _services;
        private readonly IOptionsMonitor<DapperFactoryOptions> _optionsMonitor;

        public DefaultDapperFactory(IServiceProvider services, IOptionsMonitor<DapperFactoryOptions> optionsMonitor)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _optionsMonitor = optionsMonitor ?? throw new ArgumentNullException(nameof(optionsMonitor));
        }


        /// <summary>
        ///  创建链接
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DapperClient CreateClient(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var client = new DapperClient(new ConnectionConfig { });

            var option = _optionsMonitor.Get(name).DapperActions.FirstOrDefault();
            if (option != null)
                option(client.CurrentConnectionConfig);
            else
                throw new ArgumentNullException(nameof(option));

            return client;
        }

    }
}
