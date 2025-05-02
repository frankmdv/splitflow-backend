using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SplitFlow.Application.Commands.Gestion.MovimientoDebitoCommands;
using SplitFlow.Application.Commands.Gestion.ProductoCommands;
using SplitFlow.Application.Queries.Gestion.MovimientoDebitoQuerys;
using SplitFlow.Application.Queries.Gestion.ProductoQuerys;

namespace SplitFlow.API.Controllers
{
    [ApiController]
    [Route("api/debit-movement")]
    public class MovimientoDebitoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovimientoDebitoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateMovimientoDebito(CreateMovimientoDebitoCommand command)
        {
            var movDebId = await _mediator.Send(command);
            return Ok(new { MovDebId = movDebId });
        }

        [HttpGet("/by-producto/{id}")]
        public async Task<IActionResult> GetMovimientosDebitoByProductoId(long id)
        {
            var movDeb = await _mediator.Send(new GetMovimientosByIdProducto(id));

            if (movDeb == null)
                return NotFound("No hay movimientos disponibles para este producto");

            return Ok(movDeb);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetMovimientosDebitoById(long id)
        {
            var movDeb = await _mediator.Send(new GetMovimientoDebitoByIdQuery(id));

            if (movDeb == null)
                return NotFound("Movimiento no encontrado");

            return Ok(movDeb);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllMovimientosDebito()
        {
            var movsDeb = await _mediator.Send(new GetAllMovimientosDebitoQuery());

            if (movsDeb == null || movsDeb.Count == 0)
                return NotFound("No hay movimientos registrados.");

            return Ok(movsDeb);
        }
    }
}
