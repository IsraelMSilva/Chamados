using Chamados.Application.Commands.Usuarios;
using Chamados.Application.Querys.Usuarios;
using Chamados.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chamados.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ISender _sender;

        public UsuarioController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("ObterTodosUsuarios")]
        public async Task<IActionResult> ObterTodosUsuarios()
        {
            var result = await _sender.Send(new ObterTodosUsuariosQuery());
            return Ok(result);
        }

        [HttpGet("ObterUsuarioPorId")]
        public async Task<IActionResult> ObterUsuarioPorId([FromQuery] ObterUsuarioPorIdQuery query)
        {
            try
            {
                var result = await _sender.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AdicionarUsuario")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] CriarUsuarioCommand command)
        {
            try
            {
                var result = await _sender.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AtualizarUsuario")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] AtualizarUsuarioCommand command)
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

        [HttpDelete("RemoverUsuario")]
        public async Task<IActionResult> RemoverUsuario([FromBody] RemoverUsuarioCommand command)
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
