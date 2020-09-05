using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace devboost.Test.Repository
{
    public class PedidoRepositoryTest
    {
        readonly IPedidoRepository _pedidoRepository;
        readonly IDroneRepository _droneRepository;

        public PedidoRepositoryTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _pedidoRepository = _serviceProvider.GetService<IPedidoRepository>();
            _droneRepository = _serviceProvider.GetService<IDroneRepository>();
        }

        [Fact]
        public void GetPedidos()
        {
            List<Pedido> lista = _pedidoRepository.GetPedidos(StatusPedido.aguardandoEntrega).Result;
            Assert.True(lista.Count > 0);
        }

        [Fact]
        public void GetPedidosPorStatusPesoDistancia()
        {
            List<Pedido> listaPedidos = _pedidoRepository.GetPedidos(StatusPedido.aguardandoEntrega, 2, 2).Result;
            Assert.True(listaPedidos.Count > 0);
        }

        [Fact]
        public void AddPedido()
        {
            _pedidoRepository.AddPedido(new Pedido
            {
                Id = Guid.NewGuid(),
                Peso = 4,
                DataHora = DateTime.Now,
                DistanciaParaOrigem = 2,
                StatusPedido = StatusPedido.despachado
            }).Wait();
            List<Pedido> lista = _pedidoRepository.GetPedidos(StatusPedido.despachado).Result;
            Assert.True(lista.Count > 0);
        }

        [Fact]
        public void UpdatePedido()
        {
            List<Pedido> lista = _pedidoRepository.GetPedidos(StatusPedido.aguardandoEntrega).Result;
            Pedido p = lista[0];
            p.Peso = 5;
            p.DistanciaParaOrigem = 3;

            _pedidoRepository.UpdatePedido(p).Wait();

            List<Pedido> pedidos = _pedidoRepository.GetPedidos(StatusPedido.aguardandoEntrega).Result;
            Assert.True(pedidos[0].Peso == 5);
            Assert.True(pedidos[0].DistanciaParaOrigem == 3);
        }

        [Fact]
        public void AddPedidoDrone()
        {
            List<Pedido> pedidos = _pedidoRepository.GetPedidos(StatusPedido.aguardandoEntrega).Result;
            List<Drone> drones = _droneRepository.GetDronesDisponiveis().Result;

            Drone d = drones[0];
            Pedido p = pedidos[0];

            _pedidoRepository.AddPedidoDrone(new PedidoDrone
            {
                DroneId = d.Id,
                PedidoId = p.Id
            }).Wait();

            List<Pedido> ps = _pedidoRepository.GetPedidos(StatusPedido.aguardandoEntrega).Result;
            Assert.True(ps.Any(p => p.PedidosDrones.Count > 0));
        }
    }
}
