using Domain.Pay.Core;
using Domain.Pay.Services.Commands.Payments;
using System.Threading.Tasks;

namespace Domain.Pay.Services.CommandHandlers.Interfaces
{
    public interface ICriarPaymentHandler
    {
        Task<ResponseResult> Handle(CriarPaymentCommand request);
    }
}
