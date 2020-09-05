using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace devboost.Test.Domain.Handles.Queries
{
    public class TokenHandlerTest
    {
        private ITokenHandler _tokenHandler;

        public TokenHandlerTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _tokenHandler = _serviceProvider.GetService<ITokenHandler>();
        }

        [Theory]
        [InlineData("Eric Joseph", "12345", "admin")]
        public void TestaConsultaClientePorNomeUsuario(string userName, string password, string role)
        {
            var user = new User(userName, password, role);
            var userResult = _tokenHandler.GenerateToken(user).Result;
            Assert.NotNull(userResult);
        }

        [Theory]
        [InlineData("Eric Joseph", "12345", "")]
        public void TestaConsultaClientePorNomeUsuarioErro(string userName, string password, string role)
        {
            var user = new User(userName, password, role);
            var userResult = _tokenHandler.GenerateToken(user).Result;
            Assert.Empty(userResult);
        }
    }
}
