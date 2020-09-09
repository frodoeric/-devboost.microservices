using AutoMapper;
using Domain.Pay.Services.Queries.Payments;
using Domain.Pay.Services.QueryHandler.Interfaces;
using Repository.Pay.UnitOfWork;
using Tests.Pay.TDD.Config;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Domain.Pay.Services.Commands.Payments;
using System;
using Domain.Pay.Entities;
using System.Linq;

namespace Tests.Pay.TDD.Query
{
    public class ListarPaymentsHandlerTest
    {
        private readonly IListarPaymentsHandler _listarPaymentsHandler;
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public ListarPaymentsHandlerTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _listarPaymentsHandler = _serviceProvider.GetService<IListarPaymentsHandler>();

            _unitOfWork = _serviceProvider.GetService<IUnitOfWork>();
            _mapper = _serviceProvider.GetService<IMapper>();

            AddDataBaseTest();
        }

        [Fact]
        public void ValidaListaHandle()
        {
            var result = _listarPaymentsHandler.Handle(new PaymentsQuery()).Result;

            Assert.False(result.HasFails);
        }

        public void AddDataBaseTest()
        {
            var request = new CriarPaymentCommand
            {
                PayId = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Name = "VISA",
                Bandeira = "VISA",
                NumeroCartao = "1234567890123456",
                Vencimento = DateTime.Now,
                CodigoSeguranca = 123,
                Valor = 125.52,
                Status = 1
            };
            request.Validar();
            var payment = _mapper.Map<Payment>(request);
            _unitOfWork.PaymentRepository.InsertAsync(payment).Wait();
            _unitOfWork.CommitAsync().Wait();

            Assert.False(request.Notifications.Any());
        }
    }
}
