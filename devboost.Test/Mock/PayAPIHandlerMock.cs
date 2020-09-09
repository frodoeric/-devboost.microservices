using devboost.Domain;
using devboost.Domain.Handles.Commands.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace devboost.Test.Mock
{
    public class PayAPIHandlerMock : IPayAPIHandler
    {
        public async Task<HttpResponseMessage> PostRealizarPagamento(CmmPagRequest pagamento)
        {
            var result = new HttpResponseMessage(statusCode: System.Net.HttpStatusCode.OK);
            return await Task.FromResult(result);
        }
    }
}
