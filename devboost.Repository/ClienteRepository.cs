using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        readonly DataContext _dataContext;

        public ClienteRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddCliente(Cliente cliente)
        {
            var cli = await Get(cliente.Nome);
            if (cli != null)
                throw new Exception($"Cliente {cliente.Nome} já existe na base de dados");
            _dataContext.Cliente.Add(cliente);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _dataContext.Cliente
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<Cliente> Get(string nome)
        {
            return await _dataContext.Cliente.FirstOrDefaultAsync(x => x.Nome.ToLower() == nome.ToLower());
        }

        public async Task<Cliente> GetByUserName(string userName)
        {
            return await _dataContext.Cliente.FirstOrDefaultAsync(x => x.User.UserName.ToLower() == userName.ToLower());
        }
    }
}
