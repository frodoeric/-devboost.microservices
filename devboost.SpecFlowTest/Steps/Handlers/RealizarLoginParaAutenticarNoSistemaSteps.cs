using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Queries.Filters;
using devboost.Domain.Queries.Result;
using devboost.Test.Config;
using devboost.Test.Warmup;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace devboost.SpecFlowTest.Steps
{
    [Binding]
    public class RealizarLoginParaAutenticarNoSistemaSteps
    {
        readonly ScenarioContext _context;
        readonly ILoginHandler _loginHandler;
        readonly IDataStart _dataStart;

        public RealizarLoginParaAutenticarNoSistemaSteps(ScenarioContext context)
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _loginHandler = _serviceProvider.GetService<ILoginHandler>();
            _dataStart = _serviceProvider.GetService<IDataStart>();
            // Popula base de dados
            //_dataStart.Seed();
            _context = context;
        }

        [Given(@"Que exista um usuário cadastrado na base")]
        public void GivenQueExistaUmUsuarioCadastradoNaBase()
        {
            _dataStart.Seed();
        }

        [When(@"Quando for informado o login")]
        public async Task WhenQuandoForInformadoOLogin()
        {
            var login = await _loginHandler.LoginUser(new QueryUserFilter { UserName = "Eric", Password = "12345" });
            _context.Set(login);
        }

        [Then(@"Será retornado um token")]
        public void ThenSeraRetornadoUmToken()
        {
            Assert.NotNull(_context.Get<QueryLoginResult>());
        }
    }
}
