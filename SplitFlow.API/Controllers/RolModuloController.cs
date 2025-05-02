using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SplitFlow.Application.Commands.Perfilamiento;
using SplitFlow.Application.Queries.Perfilamiento.Modulos;
using SplitFlow.Application.Queries.Perfilamiento.RolModulo;

namespace SplitFlow.API.Controllers
{
    [ApiController]
    [Route("api/role-module")]
    public class RolModuloController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RolModuloController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRolModulo(CreateRolModuloCommand command)
        {
            var rolModuloId = await _mediator.Send(command);
            return Ok(new { RolModuloId = rolModuloId });
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetRolModuloById(long id)
        {
            var rolModulo = await _mediator.Send(new GetRolModuloByIdQuery(id));

            if (rolModulo == null)
                return NotFound("RolModulo no encontrado");

            return Ok(rolModulo);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllRolModulos()
        {
            var rolModulos = await _mediator.Send(new GetAllRolModulosQuery());

            if (rolModulos == null || rolModulos.Count == 0)
                return NotFound("No hay Rolmodulos registrados.");

            return Ok(rolModulos);
        }
    }
}
