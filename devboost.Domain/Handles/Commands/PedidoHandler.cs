using devboost.Domain.Commands.Request;
using devboost.Domain.Entities;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Domain.Model;
using devboost.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Commands
{
    public class PedidoHandler : IPedidoHandler
    {
        const double LATITUDE = -23.5880684;
        const double LONGITUDE = -46.6564195;

        readonly IPedidoRepository _pedidoRepository;
        readonly IDroneRepository _droneRepository;
        readonly IClienteRepository _clienteRepository;

        public PedidoHandler(IPedidoRepository pedidoRepository, IDroneRepository droneRepository, IClienteRepository clienteRepository)
        {
            _pedidoRepository = pedidoRepository;
            _droneRepository = droneRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<Pedido> RealizarPedido(RealizarPedidoRequest pedidoRequest, string userName)
        {
            var cliente = await _clienteRepository.GetByUserName(userName);
            if (cliente == null)
                throw new Exception("Cliente não localizado");
            var distancia = GEOCalculaDistancia.CalculaDistanciaEmKM(new GEOParams(LATITUDE, LONGITUDE, cliente.Latitude, cliente.Longitude));
            var pedido = new Pedido
            {
                Id = Guid.NewGuid(),
                Cliente = cliente,
                DataHora = DateTime.Now,
                Peso = pedidoRequest.Peso,
                DistanciaParaOrigem = distancia,
                StatusPedido = StatusPedido.aguardandoEntrega
            };
            await _pedidoRepository.AddPedido(pedido);
            return pedido;
        }

        public async Task DistribuirPedido()
        {
            //Encontrar os Drones disponíveis
            var dronesDisponiveis = await _droneRepository.GetDronesDisponiveis();
            //Para cada Drone, verificar quais pedidos se encaixam na autonomia (Distância que pode percorrer) e peso
            foreach (var drone in dronesDisponiveis)
            {
                //Os pedidos precisam estar em uma distância em que o Drone possa ir e voltar, ou seja
                //Automomia do Drone dividido por 2
                var droneAutonomia = drone.AutonomiaEmKM / 2;
                var dronePeso = drone.Capacidade;
                var pedidos = await _pedidoRepository.GetPedidos(StatusPedido.aguardandoEntrega, droneAutonomia, dronePeso);
                //Varre os pedidos, e atribui ao Drone.
                //a cada atribuição, subtra-se a autonomia e peso do Drone, para ver se é possível
                //continuar atribuindo aos pedidos
                foreach (var pedido in pedidos)
                {
                    if (droneAutonomia >= pedido.DistanciaParaOrigem && dronePeso >= pedido.Peso)
                    {
                        //Vincula Pedido ao Drone, e atualiza status Drone e Pedido
                        drone.StatusDrone = StatusDrone.emTrajeto;
                        pedido.StatusPedido = StatusPedido.despachado;
                        await _pedidoRepository.AddPedidoDrone(new PedidoDrone { Drone = drone, Pedido = pedido });
                        await _pedidoRepository.UpdatePedido(pedido);
                        await _droneRepository.UpdateDrone(drone);
                        //Subtrai a autonomia e peso, para ver se cabe outro pedido
                        droneAutonomia -= pedido.DistanciaParaOrigem;
                        dronePeso -= pedido.Peso;
                    }
                }
            }
        }
    }
}
