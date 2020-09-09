using devboost.Domain.Handles.Commands;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Domain.Handles.Queries;
using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Repository;
using devboost.Repository;
using devboost.Repository.Context;
using devboost.Test.Mock;
using devboost.Test.Warmup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace devboost.Test.Config
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

            IConfiguration configuration = StartConfiguration.Configuration;
            _services.AddSingleton(x => configuration);

            _services.AddDbContext<DataContext>(options =>
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));

            _services.AddScoped<IPedidoRepository, PedidoRepository>();
            _services.AddScoped<IDroneRepository, DroneRepository>();
            _services.AddScoped<IUserRepository, UserRepository>();
            _services.AddScoped<IClienteRepository, ClienteRepository>();
            _services.AddScoped<IPagamentoRepository, PagamentoCartaoRepository>();
            _services.AddScoped<IPayAPIHandler, PayAPIHandlerMock>();
            _services.AddScoped<ITokenHandler, TokenHandler>();
            _services.AddScoped<ILoginHandler, LoginHandler>();
            _services.AddScoped<IUserHandler, UserHandler>();
            _services.AddScoped<IClienteHandler, ClienteHandler>();
            _services.AddScoped<IClientQueryHandler, ClienteQueryHandler>();
            _services.AddScoped<IPedidoHandler, PedidoHandler>();
            _services.AddScoped<IDroneHandler, DroneHandler>();
            _services.AddScoped<IDataStart, DataStart>();

            // Constroe o Provider
            ServiceProvider = _services.BuildServiceProvider();

            // Inicia base de dados em memória
            var dataStart = ServiceProvider.GetService<IDataStart>();
            dataStart.Seed();
        }
    }
}
