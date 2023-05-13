using Cloudware.Application.Commands.Log;
using Cloudware.Application.Queries.Log;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cloudware.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtem uma entidade pelo id.
        /// </summary>
        /// <param name="id">Id da entidade a ser buscada.</param>
        /// <param name="typeLog">Id do Tipo ou tambem categoria de log.</param>
        [HttpGet("item")]
        public async Task<IActionResult> Get([FromQuery] int id, [FromQuery] int typeLog)
        {
            try
            {
                var data = await _mediator.Send(new ObtainLogQuery(id, typeLog));
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// Obtem uma lista de entidades.
        /// </summary>
        /// <param name="query">Dados de filtragem.</param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<IActionResult> Get([FromQuery] ObtainLogCollectionQuery query)
        {
            try
            {
                var data = await _mediator.Send(query);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        /// <summary>
        /// Cria uma entidade.
        /// </summary>
        /// <param name="command">Dados da entidade a ser criada.</param>
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CreateLogCommand command)
        {
            try
            {
                var data = await _mediator.Send(command);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}