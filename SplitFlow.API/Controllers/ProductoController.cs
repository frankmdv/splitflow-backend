using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SplitFlow.Application.Commands.Gestion.CuentaCommands;
using SplitFlow.Application.Commands.Gestion.ProductoCommands;
using SplitFlow.Application.Queries.Gestion.CuentasQueries;
using SplitFlow.Application.Queries.Gestion.ProductoQueries;
using SplitFlow.Application.Queries.Perfilamiento.Modulos;

namespace SplitFlow.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateProducto(CreateProductoCommand command)
        {
            var productoId = await _mediator.Send(command);
            return Ok(new { ProductoId = productoId });
        }

        [HttpGet("/by-account/{id}")]
        public async Task<IActionResult> GetProductoByIdCuenta(long id)
        {
            var producto = await _mediator.Send(new GetProductoByIdCuenta(id));

            if (producto == null)
                return NotFound("No hay productos registrados para esta cuenta");

            return Ok(producto);
        }

        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> GetProductoById(long id)
        {
            var producto = await _mediator.Send(new GetProductoById(id));

            if (producto == null)
                return NotFound("Producto no encontrado");

            return Ok(producto);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllProductos()
        {
            var productos = await _mediator.Send(new GetAllProductosQuery());

            if (productos == null || productos.Count == 0)
                return NotFound("No hay productos registrados.");

            return Ok(productos);
        }
    }
}
