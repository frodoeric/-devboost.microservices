using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidoController : ControllerBase
    {
        readonly IPedidoHandler _pedidoService;
        readonly IHttpContextAccessor _accessor;

        public PedidoController(IPedidoHandler pedidoService, IHttpContextAccessor accessor)
        {
            _pedidoService = pedidoService;
            _accessor = accessor;
        }

        [HttpPost("realizarpedido")]
        public async Task<ActionResult> RealizarPedido([FromBody] RealizarPedidoRequest pedido)
        {
            try
            {
                var userName = _accessor.HttpContext.User.Identity.Name;
                var result = await _pedidoService.RealizarPedido(pedido, userName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("distribuirpedido")]
        public async Task<ActionResult> DistribuirPedido()
        {
            await _pedidoService.DistribuirPedido();
            return Ok();
        }
    }
}
