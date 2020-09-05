using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands.Interfaces;

namespace devboost.Domain.Handles.Commands
{
    public class PayAPIHandler : IPayAPIHandler
    {
        private readonly HttpClient httpClient;

        public PayAPIHandler(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<RealizarPedidoRequest> PostRealizarPedido()
        {
            return null;
        }

    }
}
