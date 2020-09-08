using AutoMapper;
using Domain.Pay.Entities;
using Domain.Pay.Services.Commands.Payments;
using Microsoft.Extensions.DependencyInjection;
using Repository.Pay.UnitOfWork;
using System;
using System.Linq;
using Tests.Pay.TDD.Config;
using Xunit;

namespace Tests.Pay.TDD.Repository
{
    public class UnitOfWorkTest
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public UnitOfWorkTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _unitOfWork = _serviceProvider.GetService<IUnitOfWork>();
            _mapper = _serviceProvider.GetService<IMapper>();
        }

        [Fact]
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
