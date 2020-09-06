using Domain.Pay.Services.CommandHandlers.Interfaces;
using Domain.Pay.Services.Commands.Payments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ICriarPaymentHandler _criarPaymentHandler;

        public PaymentController(ICriarPaymentHandler criarPaymentHandler)
        {
            _criarPaymentHandler = criarPaymentHandler;
        }

        [HttpPost]
        [Route("Pagamento")]
        public async Task<IActionResult> Payment(CriarPaymentCommand criarPaymentCommand)
        {
            var result = await _criarPaymentHandler.Handle(criarPaymentCommand);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK, "v1.0");
        }
    }
}
