using Domain.Pay.Services.Dtos.Payments;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Pay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public async Task<IActionResult> Payment(PaymentDto paymentDto)
        {

        }
    }
}
