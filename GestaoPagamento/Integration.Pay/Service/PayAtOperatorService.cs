using Integration.Pay.Dto;
using Integration.Pay.Interfaces;
using System.Threading.Tasks;

namespace Integration.Pay.Service
{
    public class PayAtOperatorService : IPayAtOperatorService
    {
        public async Task<PatyOperatorResultDto> ValidadePayAtOperator(PayOperatorFilterDto payOperatorFilterDto)
        {
            //Todo: Implementar chamada a api
            //https://5f53af5ee5de110016d51ae5.mockapi.io/api/v1/CreditCardPayment

            /*
            using var httpClient = GetHttClient();
            httpClient.BaseAddress = new Uri(_uri);
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");
            var httpResponse = await httpClient.GetAsync($"{_method}{querySERPROFilter.CNPJ}");
            if (httpResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    ? new QuerySERPROResult { Message = $"Token SERPRO inválido para essa operação. '{_token}'", TokenIsValid = false }
                    : new QuerySERPROResult { Message = $"Nenhum dado encontrado para o filtro: {querySERPROFilter.CNPJ}" };
            }
            else
            {
                var responseAsString = await httpResponse.Content.ReadAsStringAsync();
                var querySERPROResult = JsonSerializer.Deserialize<QuerySERPROResult>(responseAsString);
                querySERPROResult.RecordFound = true;
                querySERPROResult.Message = null;
                return querySERPROResult;
            }
            */

            return await Task.FromResult(new PatyOperatorResultDto());
        }
    }
}
