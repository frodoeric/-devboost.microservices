using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Xunit;

namespace devboost.Test.Domain.Handles.Queries
{
    public class DroneHandlerTest
    {
        IDroneHandler _droneHandler;

        public DroneHandlerTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _droneHandler = _serviceProvider.GetService<IDroneHandler>();
        }

        [Fact]
        public void BuscarDrone()
        {
            List<Drone> lista = _droneHandler.BuscarDrone().Result;
            Assert.True(lista.Count > 0);
        }
    }
}
