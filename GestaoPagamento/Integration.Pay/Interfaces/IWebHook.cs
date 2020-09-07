using Integration.Pay.Dto;
using System.Threading.Tasks;

namespace Integration.Pay.Interfaces
{
    public interface IWebHook
    {
        Task<string> CallPostMethod(PostMethodRequestDto postMethodDto);
    }
}
