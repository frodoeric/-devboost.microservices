using devboost.Domain;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        readonly IPedidoHandler _pedidoHandler;

        public PayController(IPedidoHandler pedidoHandler)
        {
            _pedidoHandler = pedidoHandler;
        }

        [HttpPost("atualizarstatuspagamento")]
        public async Task<ActionResult> AtualizarStatusPagamento([FromBody] CmmPagRequest cmmPagRequest)
        {
            try
            {
                var pagamento = new PagamentoCartao(
                    cmmPagRequest.Bandeira,
                    cmmPagRequest.NumeroCartao,
                    cmmPagRequest.Vencimento,
                    cmmPagRequest.CodigoSeguranca,
                    cmmPagRequest.Valor,
                    cmmPagRequest.Status)
                {
                    Id = cmmPagRequest.PayId
                };
                await _pedidoHandler.AtualizaStatusPagamento(pagamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
