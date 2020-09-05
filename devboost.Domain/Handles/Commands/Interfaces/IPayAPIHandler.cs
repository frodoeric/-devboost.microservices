using devboost.Domain.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Commands.Interfaces
{
    public interface IPayAPIHandler
    {
        public Task<HttpResponseMessage> PostRealizarPagamento(CmmPagRequest pagamento);

    }
}
