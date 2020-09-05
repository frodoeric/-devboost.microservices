using devboost.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.Domain.Repository
{
    public interface IClienteRepository
    {
        Task AddCliente(Cliente cliente);
        Task<List<Cliente>> GetAll();
        Task<Cliente> Get(string nome);
        Task<Cliente> GetByUserName(string userName);
    }
}
