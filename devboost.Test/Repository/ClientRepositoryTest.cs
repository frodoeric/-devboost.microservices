using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Test.Config;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace devboost.Test.Repository
{
    public class ClientRepositoryTest
    {
        readonly IClienteRepository _clienteRepository;

        public ClientRepositoryTest()
        {
            var _serviceProvider = new StartInjection().ServiceProvider;
            _clienteRepository = _serviceProvider.GetService<IClienteRepository>();
        }

        [Theory]
        [InlineData("Novo Cliente", "novo.cliente@domain.com", "(11)999-9999", -23.6578, -43.56079, "jefferson", "12345", "ADMIN")]
        public void TestaAdicaoDeCliente(string nome, string eMail, string telefone, double latitude, double longitude, string usuario, string senha, string perfil)
        {
            var cliente = new Cliente(nome, eMail, telefone, latitude, longitude)
            {
                User = new User(usuario, senha, perfil)
            };
            _clienteRepository.AddCliente(cliente).Wait();
        }

        [Fact]
        public void TestaRetornoDeTodosCliente()
        {
            var cliResult = _clienteRepository.GetAll().Result;
            Assert.NotNull(cliResult);
        }

        [Fact]
        public void TestaConsultaClientePorNome()
        {
            var cliResult = _clienteRepository.Get("Pantera Negra").Result;
            Assert.NotNull(cliResult);
        }

        [Fact]
        public void TestaConsultaClientePorNomeUsuario()
        {
            var cliResult = _clienteRepository.GetByUserName("jefferson").Result;
            Assert.NotNull(cliResult);
        }
    }
}
