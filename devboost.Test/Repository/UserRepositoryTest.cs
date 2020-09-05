using devboost.Domain.Repository;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace devboost.Test.Repository
{
    public class UserRepositoryTest
    {
        readonly IUserRepository _userRepository;

        public UserRepositoryTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _userRepository = _serviceProvider.GetService<IUserRepository>();
        }

        [Fact]
        public void TestaConsultaClientePorNomeUsuario()
        {
            var userResult = _userRepository.GetUser("jefferson").Result;
            Assert.NotNull(userResult);
        }
    }
}
