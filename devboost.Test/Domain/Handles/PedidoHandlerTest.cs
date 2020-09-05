using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace devboost.Test.Domain.Handles
{
    public class PedidoHandlerTest
    {
        readonly IPedidoHandler _pedidoHandler;
        readonly IPagamentoRepository _pagamentoRepository;
        readonly IPedidoRepository _pedidoRepository;

        public PedidoHandlerTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _pedidoHandler = _serviceProvider.GetService<IPedidoHandler>();
            _pagamentoRepository = _serviceProvider.GetService<IPagamentoRepository>();
            _pedidoRepository = _serviceProvider.GetService<IPedidoRepository>();
        }

        [Theory]
        [InlineData(5, "Eric")]
        public void TestaRealizarPedido(int peso, string usuario)
        {
            var pedido = _pedidoHandler.RealizarPedido(new RealizarPedidoRequest
            { 
                Peso = peso,
                Bandeira = "AMEX",
                Numero = "3355.5522.6622",
                CodigoSeguranca = 123,
                Vencimento = DateTime.Now,
                Valor = (decimal)450.45
            },
            usuario).Result;
            Assert.NotNull(pedido);
        }

        [Fact]
        public void TestaDistribuirPedido()
        {
            _pedidoHandler.DistribuirPedido().Wait();
        }

        [Fact]
        public void TestaAtualizaStatusPagamento()
        {
            var pagtos = _pagamentoRepository.GetAll().Result;
            foreach (var p in pagtos)
            {
                var pedido = _pedidoRepository.GetPedidoByPagamento(p.Id).Result;
                if (pedido != null)
                {
                    p.Status = StatusCartao.aprovado;
                    _pedidoHandler.AtualizaStatusPagamento(p).Wait();
                }
            }
        }
    }
}
