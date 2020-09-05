using devboost.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Queries.Interfaces
{
    public interface IClientQueryHandler
    {
        Task<List<Cliente>> GetAll();
    }
}
