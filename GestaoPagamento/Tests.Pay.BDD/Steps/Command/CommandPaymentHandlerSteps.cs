using TechTalk.SpecFlow;
using Tests.Pay.TDD.Config;

namespace Tests.Pay.BDD.Steps.Command
{
    [Binding]
    public class CommandPaymentHandlerSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private StartInjection _startInjection;

        public CommandPaymentHandlerSteps(ScenarioContext scenarioContext, StartInjection startInjection)
        {
            _scenarioContext = scenarioContext;
            _startInjection = StartInjection
        }

        [Given(@"Exista Payments cadastrados")]
        public void GivenExistaPaymentsCadastrados()
        {
            
        }
        
        [When(@"Consultar Pagamentos")]
        public void WhenConsultarPagamentos()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Cadastrar pagamentos")]
        public void ThenCadastrarPagamentos()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
