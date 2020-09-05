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
        [HttpPost]
        [Route("Pagamento")]
        public async Task<IActionResult> Payment(CriarPaymentCommand criarPaymentCommand)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK, "v1.0");
        }
    }
}
