using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SplitFlow.Application.Commands.Perfilamiento;
using SplitFlow.Application.Queries.Perfilamiento.Modulos;

namespace SplitFlow.API.Controllers
{
    [ApiController]
    [Route("api/module")]
    public class ModuloController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ModuloController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateModulo(CreateModuloCommand command)
        {
            var moduloId = await _mediator.Send(command);
            return Ok(new { ModuloId = moduloId });
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> GetModuloById(long id)
        {
            var modulo = await _mediator.Send(new GetModuloByIdQuery(id));

            if (modulo == null)
                return NotFound("Modulo no encontrado");

            return Ok(modulo);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllModulos()
        {
            var modulos = await _mediator.Send(new GetAllModulosQuery());

            if (modulos == null || modulos.Count == 0)
                return NotFound("No hay modulos registrados.");

            return Ok(modulos);
        }
    }
}
