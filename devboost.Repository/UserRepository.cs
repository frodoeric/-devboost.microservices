using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace devboost.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddUser(User user)
        {
            _dataContext.User.Add(user);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<User> GetUser(string userName)
        {
            return await _dataContext.User.FirstOrDefaultAsync(x => x.UserName.ToLower() == userName.ToLower());
        }
    }
}
