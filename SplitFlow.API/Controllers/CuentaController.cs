using MediatR;
using Microsoft.AspNetCore.Mvc;
using SplitFlow.Application.Commands.Gestion.CuentaCommands;
using SplitFlow.Application.Commands.Parametrizacion;
using SplitFlow.Application.Queries.Gestion.CuentasQuerys;
using SplitFlow.Application.Queries.Parametrizacion.ParEspe;

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

        [HttpGet("cuentas/por-usuario/{id}")]
        public async Task<IActionResult> GetCuentaById(long id)
        {
            var cuenta = await _mediator.Send(new GetCuentasByIdUsuarioQuery(id));

            if (cuenta == null)
                return NotFound("No hay cuentas registradas para este usuario");

            return Ok(cuenta);
        }
    }
}
