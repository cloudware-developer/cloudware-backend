using Cloudware.Application.Commands.Company;
using Cloudware.Application.Queries.Company;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cloudware.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
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
                var data = await _mediator.Send(new ObtainCompanyQuery(id));
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
        public async Task<IActionResult> Get([FromQuery] ObtainCompanyCollectionQuery query)
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
        public async Task<IActionResult> Post([FromBody] CreateCompanyCommand command)
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
        public async Task<IActionResult> Put([FromBody] UpdateCompanyCommand command)
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
                var data = await _mediator.Send(new DeleteCompanyCommand(id));
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

    }
}