using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Domain.Model;
using devboost.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Commands
{
    public class ClienteHandler : IClienteHandler
    {
        readonly IClienteRepository _clienteRepository;
        readonly IUserRepository _userRepository;

        public ClienteHandler(IClienteRepository clienteRepository, IUserRepository userRepository)
        {
            _clienteRepository = clienteRepository;
            _userRepository = userRepository;
        }

        public async Task AddCliente(ClienteRequest cliente, string userName)
        {
            var user = await _userRepository.GetUser(userName);
            if (user == null)
                throw new Exception("Não foi possível encontrar o usuário autenticado.");
            var cli = new Cliente(cliente.Nome, cliente.EMail, cliente.Telefone, cliente.Latitude, cliente.Longitude)
            {
                User = user
            };
            if (!cli.IsValid())
                throw new Exception("Dados do cliente inválido, os campos: Nome, EMail, Telefone, Latitude e Longitude são obrigatórios.");
            await _clienteRepository.AddCliente(cli);
        }
    }
}
