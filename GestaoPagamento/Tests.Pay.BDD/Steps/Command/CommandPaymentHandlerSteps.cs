using Domain.Pay.Services.CommandHandlers.Interfaces;
using Domain.Pay.Services.Commands.Payments;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;
using Tests.Pay.TDD.Config;

namespace Tests.Pay.BDD.Steps.Command
{
    [Binding]
    public class CommandPaymentHandlerSteps
    {
        readonly ScenarioContext _context;
        readonly ICriarPaymentHandler _criarPaymentHandler;

        public CommandPaymentHandlerSteps(ScenarioContext context, ICriarPaymentHandler criarPaymentHandler)
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _context = context;
            _criarPaymentHandler = _serviceProvider.GetServices<ICriarPaymentHandler>();
        }

        [Given(@"Nao Exista Payments cadastrados")]
        public void GivenNaoExistaPaymentsCadastrados()
        {
            _criarPaymentHandler.Handle(new CriarPaymentCommand 
            {

            });
        }
    }
}
