using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace devboost.Test.Repository
{
    public class DroneRepositoryTest
    {
        readonly IDroneRepository _droneRepository;

        public DroneRepositoryTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _droneRepository = _serviceProvider.GetService<IDroneRepository>();
        }

        [Theory]
        [InlineData(20, 12, 35, 15, 100, StatusDrone.disponivel)]
        public void TestaAdicaoDeDrone(int id, int capacidade, int velocidade, int autonomia, int carga, StatusDrone status)
        {
            var drone = new Drone()
            {
                Id = id,
                Capacidade = capacidade,
                Velocidade = velocidade,
                Autonomia = autonomia,
                Carga = carga,
                StatusDrone = status
            };
            _droneRepository.AddDrone(drone).Wait();
        }

        [Fact]
        public void TestaRetornoDeTodosDrone()
        {
            var droneResult = _droneRepository.GetAll().Result;
            Assert.NotNull(droneResult);
        }

        [Fact]
        public void TestaConsultaDroneDisponivel()
        {
            var droneResult = _droneRepository.GetDronesDisponiveis().Result;
            Assert.NotNull(droneResult);
        }

        [Theory]
        [InlineData(1, 11, 30, 14, 99, StatusDrone.emTrajeto)]
        public void TestaAtualizaDrone(int id, int capacidade, int velocidade, int autonomia, int carga, StatusDrone status)
        {
            var drone = _droneRepository.GetById(id).Result;
            drone.Capacidade = capacidade;
            drone.Velocidade = velocidade;
            drone.Autonomia = autonomia;
            drone.Carga = carga;
            drone.StatusDrone = status;
            _droneRepository.UpdateDrone(drone).Wait();
        }
    }
}
