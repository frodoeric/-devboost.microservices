using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Repository.Context;
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

        public async Task<Pagamento> AddPagamento(Pagamento pagamento)
        {
            _dataContext.PagamentoCartao.Add((PagamentoCartao)pagamento);
            await _dataContext.SaveChangesAsync();
            return pagamento;
        }
    }
}
