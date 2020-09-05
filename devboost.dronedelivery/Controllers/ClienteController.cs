using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Commands.Interfaces;
using devboost.Domain.Handles.Queries.Interfaces;
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
    public class ClienteController : ControllerBase
    {
        readonly IClienteHandler _clienteHandler;
        readonly IClientQueryHandler _clientQueryHandler;
        readonly IHttpContextAccessor _accessor;

        public ClienteController(IClienteHandler clienteHandler, IClientQueryHandler clientQueryHandler, IHttpContextAccessor accessor)
        {
            _clienteHandler = clienteHandler;
            _clientQueryHandler = clientQueryHandler;
            _accessor = accessor;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _clientQueryHandler.GetAll();
            return Ok(result);
        }

        [HttpPost("adicionarcliente")]
        public async Task<ActionResult> AdicionarCliente([FromBody] ClienteRequest clienteRequest)
        {
            try
            {
                var userName = _accessor.HttpContext.User.Identity.Name;
                await _clienteHandler.AddCliente(clienteRequest, userName);
                return Ok("Cliente cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
