using devboost.Domain.Model;
using System.Threading.Tasks;

namespace devboost.Domain.Repository
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<User> GetUser(string userName);
    }
}
