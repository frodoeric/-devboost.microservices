using devboost.Domain.Handles.Commands.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Commands
{
    public class PayAPIHandler : IPayAPIHandler
    {
        readonly HttpClient httpClient;
        readonly string uri = "https://localhost:44339/api/payment/pagamento";

        public PayAPIHandler(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> PostRealizarPagamento(CmmPagRequest pagamento)
        {
            try
            {
                StringContent pedidoJson = new StringContent(JsonConvert.SerializeObject(pagamento), Encoding.UTF8, "application/json");
                var result = await httpClient.PostAsync(uri, pedidoJson);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
