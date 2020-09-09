using IoC.Pay;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Tests.Pay.TDD.Config
{
    public class StartInjection
    {
        public StartInjection()
        {
            BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider { get; private set; }

        void BuildServiceProvider()
        {
            var _services = new ServiceCollection();
            _services.RegisterDbContextInMemory();
            _services.RegisterServices(true);

            ServiceProvider = _services.BuildServiceProvider();
        }
    }
}
