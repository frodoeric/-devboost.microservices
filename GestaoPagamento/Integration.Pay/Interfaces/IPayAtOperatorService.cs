using Integration.Pay.Dto;
using System.Threading.Tasks;

namespace Integration.Pay.Interfaces
{
    public interface IPayAtOperatorService
    {
        Task<PayOperatorResultDto> ValidadePayAtOperator(PayOperatorFilterDto payOperatorFilterDto);
    }
}
