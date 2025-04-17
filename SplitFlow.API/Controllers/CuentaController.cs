using MediatR;
using Microsoft.AspNetCore.Mvc;
using SplitFlow.Application.Commands.Gestion.CuentaCommands;
using SplitFlow.Application.Commands.Parametrizacion;

namespace SplitFlow.API.Controllers
{
    [ApiController]
    [Route("api/Cuenta")]
    public class CuentaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CuentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCuenta(CreateCuentaCommand command)
        {
            var cuentaId = await _mediator.Send(command);
            return Ok(new { CuentaId = cuentaId });
        }
    }
}
