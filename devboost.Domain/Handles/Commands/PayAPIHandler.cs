using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands.Interfaces;
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

        public async Task<HttpResponseMessage> PostRealizarPagamento()
        {
            CmmPagRequest realizarPagamentoRequest = new CmmPagRequest();

            StringContent pedidoJson = new StringContent(JsonConvert.SerializeObject(realizarPagamentoRequest));

            var result = await httpClient.PostAsync(uri, pedidoJson);
            return result;
        }

    }
}
