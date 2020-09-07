using Domain.Pay.Services.CommandHandlers.Interfaces;
using Domain.Pay.Services.Commands.Payments;
using Domain.Pay.Services.Dtos.Payments;
using Domain.Pay.Services.Queries.Payments;
using Domain.Pay.Services.QueryHandler.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ICriarPaymentHandler _criarPaymentHandler;
        private readonly IListarPaymentsHandler _listarPaymentsHandler;

        public PaymentController(ICriarPaymentHandler criarPaymentHandler, IListarPaymentsHandler listarPaymentsHandler)
        {
            _criarPaymentHandler = criarPaymentHandler;
            _listarPaymentsHandler = listarPaymentsHandler;
        }

        [HttpPost]
        [Route("Pagamento")]
        public async Task<IActionResult> Payment([FromBody]CriarPaymentCommand criarPaymentCommand)
        {
            var result = await _criarPaymentHandler.Handle(criarPaymentCommand);
            return Ok(result);
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> ListarPagamentos()
        {
            var result = await _listarPaymentsHandler.Handle(new PaymentsQuery());

            if (result.HasFails)
                return BadRequest(result.HasFails);

            return Ok(result.Data);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK, "v1.0");
        }
    }
}
