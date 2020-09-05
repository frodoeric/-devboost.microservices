using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace devboost.Test.Repository
{
    public class PagamentoRepositoryTest
    {
        readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoRepositoryTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _pagamentoRepository = _serviceProvider.GetService<IPagamentoRepository>();
        }

        [Fact]
        public void TestaGetAll()
        {
            var pagtos = _pagamentoRepository.GetAll().Result;
            Assert.NotEqual(0, pagtos.Count);
        }

        [Fact]
        public void TestaGetById()
        {
            var pagtos = _pagamentoRepository.GetAll().Result;
            foreach (var p in pagtos)
            {
                var pagto = _pagamentoRepository.GetById(p.Id).Result;
                Assert.NotNull(pagto);
            }
        }

        [Fact]
        public void TestaAtualizaPagamento()
        {
            var pagtos = _pagamentoRepository.GetAll().Result;
            foreach (var p in pagtos)
            {
                var pagto = (PagamentoCartao)_pagamentoRepository.GetById(p.Id).Result;
                pagto.Status = StatusCartao.aprovado;
                _pagamentoRepository.UpdatePagamento(pagto).Wait();
                Assert.NotNull(pagto);
            }
        }

        [Fact]
        public void TestaAdicionaPagamento()
        {
            var pagto = new PagamentoCartao("VISA", "9832.5252", DateTime.Now, 123, (decimal)520.52, StatusCartao.aguardandoAprovacao);
            _pagamentoRepository.AddPagamento(pagto).Wait();
            Assert.NotNull(pagto);
        }
    }
}
