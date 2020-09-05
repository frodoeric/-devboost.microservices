using devboost.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.Domain.Repository
{
    public interface IPagamentoRepository
    {
        Task<List<PagamentoCartao>> GetAll();
        Task<Pagamento> GetById(Guid id);
        Task<Pagamento> UpdatePagamento(Pagamento pagamento);
        Task<Pagamento> AddPagamento(Pagamento pagamento);
    }
}
