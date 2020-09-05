using devboost.Domain.Commands.Request;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Commands.Interfaces
{
    public interface IClienteHandler
    {
        Task AddCliente(ClienteRequest cliente, string userName);
    }
}
