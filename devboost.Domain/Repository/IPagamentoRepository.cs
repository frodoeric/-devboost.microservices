using devboost.Domain.Model;
using System.Threading.Tasks;

namespace devboost.Domain.Repository
{
    public interface IPagamentoRepository
    {
        Task<Pagamento> AddPagamento(Pagamento pagamento);
    }
}
