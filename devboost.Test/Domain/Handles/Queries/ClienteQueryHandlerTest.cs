using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace devboost.Test.Domain.Handles.Queries
{
    public class ClienteQueryHandlerTest
    {
        readonly IClientQueryHandler _clientQueryHandler;

        public ClienteQueryHandlerTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _clientQueryHandler = _serviceProvider.GetService<IClientQueryHandler>();
        }

        [Fact]
        public void TestaRetornoTodosCliente()
        {
            var cliResult = _clientQueryHandler.GetAll().Result;
            Assert.NotNull(cliResult);
        }
    }
}
