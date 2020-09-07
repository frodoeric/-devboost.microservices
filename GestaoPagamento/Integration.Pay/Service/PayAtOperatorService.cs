using Integration.Pay.Dto;
using Integration.Pay.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Pay.Service
{
    public class PayAtOperatorService : IPayAtOperatorService
    {
        public async Task<PatyOperatorResultDto> ValidadePayAtOperator(PayOperatorFilterDto payOperatorFilterDto)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(payOperatorFilterDto), Encoding.UTF8, "application/json");
            var postRequest = new PostMethodRequestDto(
                url: "https://5f53af5ee5de110016d51ae5.mockapi.io/api/v1/",
                method: "CreditCardPayment",
                bodyRequest: jsonContent
            );
            var result = HttpPostService.HttpPost(postRequest);
            if (result.StatusCode == HttpStatusCode.OK)
            {

            }
                

            return await Task.FromResult(new PatyOperatorResultDto());
        }
    }
}
