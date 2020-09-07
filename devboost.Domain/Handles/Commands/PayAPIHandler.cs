using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Domain.Model;
using Newtonsoft.Json;

namespace devboost.Domain.Handles.Commands
{
    public class PayAPIHandler : IPayAPIHandler
    {
        private readonly HttpClient httpClient;
        string uri = "https://localhost:44339/api/payment/pagamento";

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

                throw;
            }
            // CmmPagRequest realizarPagamentoRequest = new CmmPagRequest();

            
        }

    }
}
