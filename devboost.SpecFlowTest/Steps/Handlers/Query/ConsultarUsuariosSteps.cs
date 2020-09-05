using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Domain.Queries.Filters;
using devboost.Test.Config;
using devboost.Test.Warmup;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace devboost.SpecFlowTest.Steps.Handlers.Query
{
    [Binding]
    public class ConsultarUsuariosSteps
    {
        readonly ScenarioContext _context;
        readonly IDataStart _dataStart;
        readonly IUserHandler _userHandler;

        public ConsultarUsuariosSteps(ScenarioContext context)
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _dataStart = _serviceProvider.GetService<IDataStart>();
            _userHandler = _serviceProvider.GetService<IUserHandler>();
            _context = context;
        }

        [Given(@"Que exista usuarios cadastrados")]
        public void GivenQueExistaUsuariosCadastrados()
        {
            _dataStart.Seed();
        }

        [When(@"Quando consultar")]
        public async Task WhenQuandoConsultar()
        {
            var user = await _userHandler.GetUser(new QueryUserFilter { UserName = "Allan", Password = "12345" });
            _context.Set(user);            
        }

        [Then(@"Será retornado uma lista de clientes cadastrados")]
        public void ThenSeraRetornadoUmaListaDeClientesCadastrados()
        {
            Assert.NotNull(_context.Get<User>());
        }
    }
}
