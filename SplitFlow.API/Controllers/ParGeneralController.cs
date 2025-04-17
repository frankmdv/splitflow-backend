using MediatR;
using Microsoft.AspNetCore.Mvc;
using SplitFlow.Application.Commands.Parametrizacion;
using SplitFlow.Application.Commands.Perfilamiento;
using SplitFlow.Application.Queries.Parametrizacion.ParGen;
using SplitFlow.Application.Queries.Perfilamiento.Roles;

namespace SplitFlow.API.Controllers
{
    [ApiController]
    [Route("api/ParametrosGenerales")]
    public class ParGeneralController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParGeneralController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateParGeneral(CreateParGeneralCommand command)
        {
            var parGenId = await _mediator.Send(command);
            return Ok(new { ParGenId = parGenId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaGenById(long id)
        {
            var parGen = await _mediator.Send(new GetParGenByIdQuery(id));

            if (parGen == null)
                return NotFound("Parametro general no encontrado");

            return Ok(parGen);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParGeneral()
        {
            var parGens = await _mediator.Send(new GetAllParGenQuery());

            if (parGens == null || parGens.Count == 0)
                return NotFound("No hay parametros generales registrados.");

            return Ok(parGens);
        }
    }
}
