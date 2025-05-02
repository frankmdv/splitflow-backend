using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SplitFlow.Application.Commands.Parametrizacion;
using SplitFlow.Application.Queries.Parametrizacion.ParEspe;
using SplitFlow.Application.Queries.Parametrizacion.ParGen;

namespace SplitFlow.API.Controllers
{
    [ApiController]
    [Route("api/specific-parameter")]
    public class ParEspecificoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParEspecificoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateParEspecifico(CreateParEspecificoCommand command)
        {
            var parEspId = await _mediator.Send(command);
            return Ok(new { ParEspId = parEspId });
        }

        [HttpGet("/by-general-parameter/{id}")]
        public async Task<IActionResult> GetParEspByParGenId(long id)
        {
            var parEspe = await _mediator.Send(new GetParEspByIdParGenQuery(id));

            if (parEspe == null)
                return NotFound("No hay parametros especificos registrados");

            return Ok(parEspe);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetParEspById(long id)
        {
            var parEspe = await _mediator.Send(new GetParEspByIdQuery(id));

            if (parEspe == null)
                return NotFound("Parametro especifico no encontrado");

            return Ok(parEspe);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllParEspecificos()
        {
            var parEspes = await _mediator.Send(new GetAllParEspQuery());

            if (parEspes == null || parEspes.Count == 0)
                return NotFound("No hay parametros especificos registrados.");

            return Ok(parEspes);
        }
    }
}
