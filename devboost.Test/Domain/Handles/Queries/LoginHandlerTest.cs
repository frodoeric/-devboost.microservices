using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Queries.Filters;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace devboost.Test.Domain.Handles.Queries
{
    public class LoginHandlerTest
    {
        readonly ILoginHandler _loginHandler;

        public LoginHandlerTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _loginHandler = _serviceProvider.GetService<ILoginHandler>();
        }

        [Theory]
        [InlineData("Eric", "12345")]
        public void TestaLoginUser(string userName, string password)
        {
            var login = _loginHandler.LoginUser(new QueryUserFilter { UserName = userName, Password = password }).Result;
            Assert.NotNull(login);
        }
    }
}
