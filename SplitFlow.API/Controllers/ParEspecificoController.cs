using MediatR;
using Microsoft.AspNetCore.Mvc;
using SplitFlow.Application.Commands.Parametrizacion;
using SplitFlow.Application.Queries.Parametrizacion.ParEspe;
using SplitFlow.Application.Queries.Parametrizacion.ParGen;

namespace SplitFlow.API.Controllers
{
    [ApiController]
    [Route("api/ParametrosEspecificos")]
    public class ParEspecificoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParEspecificoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateParEspecifico(CreateParEspecificoCommand command)
        {
            var parEspId = await _mediator.Send(command);
            return Ok(new { ParEspId = parEspId });
        }

        [HttpGet("parametros-especificos/por-par-general/{id}")]
        public async Task<IActionResult> GetParEspByParGenId(long id)
        {
            var parEspe = await _mediator.Send(new GetParEspByIdParGenQuery(id));

            if (parEspe == null)
                return NotFound("No hay parametros especificos registrados");

            return Ok(parEspe);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParEspById(long id)
        {
            var parEspe = await _mediator.Send(new GetParEspByIdQuery(id));

            if (parEspe == null)
                return NotFound("Parametro especifico no encontrado");

            return Ok(parEspe);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParEspecificos()
        {
            var parEspes = await _mediator.Send(new GetAllParEspQuery());

            if (parEspes == null || parEspes.Count == 0)
                return NotFound("No hay parametros especificos registrados.");

            return Ok(parEspes);
        }
    }
}
