using Domain.Pay.Core;
using Domain.Pay.Services.Queries.Payments;
using System.Threading.Tasks;

namespace Domain.Pay.Services.QueryHandler.Interfaces
{
    public interface IListarPaymentsHandler 
    {
        Task<ResponseResult> Handle(PaymentsQuery paymentsQuery);
    }
}
