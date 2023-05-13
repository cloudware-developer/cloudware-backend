using Cloudware.Application.Commands.User;
using Cloudware.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cloudware.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtem uma entidade pelo id.
        /// </summary>
        /// <param name="id">Id da entidade a ser buscada.</param>
        [HttpGet("item")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            try
            {
                var data = await _mediator.Send(new ObtainUserQuery(id));
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
        public async Task<IActionResult> Get([FromQuery] ObtainUserCollectionQuery query)
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
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
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

        /// <summary>
        /// Atualiza uma entidade.
        /// </summary>
        /// <param name="command">Dados da entidade a ser atualizada.</param>
        [HttpPut("update")]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
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

        /// <summary>
        /// Atualiza uma entidade.
        /// </summary>
        /// <param name="command">Dados da entidade a ser atualizada.</param>
        [HttpPut("update/password")]
        public async Task<IActionResult> Put([FromBody] UpdateUserPasswordCommand command)
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

        /// <summary>
        /// Deleta uma entidade.
        /// </summary>
        /// <param name="id">Id da entidade a ser deletada.</param>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                var data = await _mediator.Send(new DeleteUserCommand(id));
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

    }
}