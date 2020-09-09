using Domain.Pay.Services.CommandHandlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Pay.TDD.Config;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Domain.Pay.Services.Commands.Payments;

namespace Tests.Pay.TDD.Repository
{
    public class CriarPaymentHandlerTest
    {
        readonly ICriarPaymentHandler _criarPaymentHandler;


        public CriarPaymentHandlerTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _criarPaymentHandler = _serviceProvider.GetService<ICriarPaymentHandler>();

        }      

        [Fact]
        public void TesteCriarPaymentHandlerValidar()
        {
            var payCommand = new CriarPaymentCommand(new Guid(),DateTime.Now,"Afonso","Visa","1234567891011115",DateTime.Now.AddMonths(9),32,8523,1);

            payCommand.Validar();

            var result = _criarPaymentHandler.Handle(payCommand).Result;

            
            Assert.False(result.HasFails);

            
        }



    }
}

