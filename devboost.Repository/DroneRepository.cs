using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.Repository
{
    public class DroneRepository : IDroneRepository
    {
        readonly DataContext _dataContext;

        public DroneRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Drone> GetById(int id)
        {
            var drone = await _dataContext.Drone
                .FirstOrDefaultAsync(x => x.Id == id);
            return drone;
        }

        public async Task<List<Drone>> GetAll()
        {
            var drones = await _dataContext.Drone
                .Include(x => x.PedidosDrones)
                .ThenInclude(x => x.Pedido)
                .ThenInclude(x => x.Cliente)
                .ToListAsync();
            return drones;
        }

        public async Task<List<Drone>> GetDronesDisponiveis()
        {
            return await _dataContext.Drone
                .Where(x => (int)x.StatusDrone == (int)StatusDrone.disponivel)
                .ToListAsync();
        }

        public async Task AddDrone(Drone drone)
        {
            _dataContext.Drone.Add(drone);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateDrone(Drone drone)
        {
            _dataContext.Drone.Update(drone);
            await _dataContext.SaveChangesAsync();
        }
    }
}
