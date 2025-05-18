using MediatR;
using Microsoft.AspNetCore.Mvc;
using SplitFlow.Application.Commands.Gestion.MovimientoCreditoCommands;

namespace SplitFlow.API.Controllers
{
    [ApiController]
    [Route("api/credit-movement")]
    public class MovimientoCreditoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovimientoCreditoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateMovimientoCredito(CreateMovimientoCreditoCommand command)
        {
            var movCredId = await _mediator.Send(command);
            return Ok(new { MovCredId = movCredId });
        }
    }
}
