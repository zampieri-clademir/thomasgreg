using AutoMapper;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ThomasGregChallenge.API.Exceptions;
using ThomasGregChallenge.Application.Features.Cliente.AdicionarCliente;

namespace ThomasGregChallenge.API.Features.Cliente
{
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator, IMapper mapper)    
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Adiciona novo Cliente
        /// </summary>
        /// <param name="ClienteCommand">Contém as informações necessarias para criar um Cliente</param>
        /// <response code="200">Success, Chamada realizada com sucesso.</response>
        /// <response code="400">Bad Request, chamada inválida.</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionPayload), StatusCodes.Status400BadRequest)]
        [HttpPost("AdicionarCliente")]
        [Authorize]
        public async Task<IActionResult> AdicionarCliente([FromBody] AdicionarClienteCommand ClienteCommand)
        {
            if (ClienteCommand == null)
                throw new ArgumentNullException("O parâmetro não pode ser nulo");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var executarAcaoMediador = () => _mediator.Send(ClienteCommand);

            var resultado = await executarAcaoMediador();

            if (resultado == Guid.Empty)
                return BadRequest("Erro no processamento");

            return Ok(resultado);
        }
    }
}
