using Domain.Pay.Entities;
using Domain.Pay.Services.CommandHandlers.Interfaces;
using Domain.Pay.Services.Commands.Payments;
using Domain.Pay.Services.Queries.Payments;
using Domain.Pay.Services.QueryHandler.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Tests.Pay.TDD.Config;
using Xunit;

namespace Tests.Pay.BDD.Steps.Command
{
    [Binding]
    public class CommandPaymentHandlerSteps
    {
        readonly ScenarioContext _context;
        readonly ICriarPaymentHandler _criarPaymentHandler;
        readonly IListarPaymentsHandler _listarPaymentsHandler;

        public CommandPaymentHandlerSteps(ScenarioContext context)
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _context = context;
            _criarPaymentHandler = _serviceProvider.GetService<ICriarPaymentHandler>();
            _listarPaymentsHandler = _serviceProvider.GetService<IListarPaymentsHandler>();

        }

        [Given(@"Nao Exista Payments cadastrados")]
        public async Task GivenNaoExistaPaymentsCadastrados()
        {
            CriarPaymentCommand criarPayment = new CriarPaymentCommand
            {
                PayId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                CreatedAt = DateTime.Parse("2020-09-07T21:19:50.304Z"),
                Name = "Eric",
                Bandeira = "Mastercard",
                NumeroCartao = "1111111111111111",
                Vencimento = DateTime.Parse("2020-09-07T21:19:50.304Z"),
                CodigoSeguranca = 145,
                Valor = 40,
                Status = 1
            };

            await _criarPaymentHandler.Handle(criarPayment);
            var payment = await _listarPaymentsHandler.Handle(new PaymentsQuery());
            Assert.NotNull(payment);
        }
    }
}
