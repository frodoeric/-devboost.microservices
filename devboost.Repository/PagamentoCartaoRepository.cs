using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.Repository
{
    public class PagamentoCartaoRepository : IPagamentoRepository
    {
        readonly DataContext _dataContext;

        public PagamentoCartaoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<PagamentoCartao>> GetAll()
        {
            return await _dataContext.PagamentoCartao.ToListAsync();
        }

        public async Task<Pagamento> GetById(Guid id)
        {
            return await _dataContext.PagamentoCartao.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pagamento> UpdatePagamento(Pagamento pagamento)
        {
            _dataContext.PagamentoCartao.Update((PagamentoCartao)pagamento);
            await _dataContext.SaveChangesAsync();
            return pagamento;
        }

        public async Task<Pagamento> AddPagamento(Pagamento pagamento)
        {
            _dataContext.PagamentoCartao.Add((PagamentoCartao)pagamento);
            await _dataContext.SaveChangesAsync();
            return pagamento;
        }
    }
}
