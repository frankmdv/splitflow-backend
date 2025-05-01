using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SplitFlow.Application.Commands.Perfilamiento;
using SplitFlow.Application.Queries.Perfilamiento.Roles;

namespace SplitFlow.API.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        {
            var roleId = await _mediator.Send(command);
            return Ok(new {RoleId = roleId});
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetRoleById(long id)
        {
            var role = await _mediator.Send(new GetRoleByIdQuery(id));

            if (role == null)
                return NotFound("Rol no encontrado");

            return Ok(role);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _mediator.Send(new GetAllRolesQuery());

            if (roles == null || roles.Count == 0)
                return NotFound("No hay roles registrados.");

            return Ok(roles);
        }
    }
}
