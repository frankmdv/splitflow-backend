using MediatR;
using Microsoft.AspNetCore.Mvc;
using SplitFlow.Application.Commands.Perfilamiento;
using SplitFlow.Application.Queries.Perfilamiento.Users;

namespace SplitFlow.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(new { UserId = userId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));

            if (user == null)
                return NotFound("Usuario no encontrado");

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());

            if (users == null || users.Count == 0)
                return NotFound("No hay usuarios registrados.");

            return Ok(users);
        }
    }
}
