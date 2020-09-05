using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Domain.Queries.Filters;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Domain.Handles.Queries
{
    public class UserHandleTest
    {
        readonly IUserHandler _userHandler;

        public UserHandleTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _userHandler = _serviceProvider.GetService<IUserHandler>();
        }

        [Fact]
        public void GetUser()
        {
            User user = _userHandler.GetUser(new QueryUserFilter
            {
                UserName = "Allan"
            }).Result;
            Assert.NotNull(user);
        }
    }
}
