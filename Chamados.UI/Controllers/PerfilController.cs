using Chamados.Application.Commands.Perfis;
using Chamados.Application.Querys.Perfis;
using Chamados.Domain.Entities;
using Chamados.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chamados.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly ISender _sender;

        public PerfilController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("ObterTodosPerfis")]
        public async Task<IActionResult> ObterTodosPerfis()
        {
            var result = await _sender.Send(new ObterTodosPerfisQuery());

            return Ok(result);
        }

        [HttpGet("ObterPerfilPorId")]
        public async Task<IActionResult> ObterPerfilPorId([FromQuery] ObterPerfilPorIdQuery query)
        {
            try
            {
                return Ok(await _sender.Send(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AdicionarPerfil")]
        public async Task<IActionResult> AdicionarPerfil([FromBody] CriarPerfilCommand command)
        {
            try
            {
                return Ok(await _sender.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarPerfil")]
        public async Task<IActionResult> AtualizarPerfil([FromBody] AtualizarPerfilCommand command)
        {
            try
            {
                return Ok(await _sender.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoverPerfil")]
        public async Task<IActionResult> RemoverPerfil([FromBody] RemoverPerfilCommand command)
        {
            try
            {
                await _sender.Send(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
