using Integration.Pay.Dto;
using Integration.Pay.Interfaces;
using Integration.Pay.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.Pay.TDD.Integration
{
    public class PayAtOperatorServiceTest
    {
        readonly IPayAtOperatorService _payAtOperatorService;

        public PayAtOperatorServiceTest()
        {
            _payAtOperatorService = new PayAtOperatorService();
        }

        [Fact]
        public void ValidadePayAtOperatorTest()
        {
            var result = _payAtOperatorService.ValidadePayAtOperator(new PayOperatorFilterDto()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Name = "Cornell Mayer",
                Bandeira = "VISA",
                NumeroCartao = "123.456.789",
                Vencimento = DateTime.Now,
                CodigoSeguranca = 123,
                Valor = (decimal)532.31,
                Status = "Envio"
            }).Result;
            Assert.True(result.Status);
        }
    }
}
