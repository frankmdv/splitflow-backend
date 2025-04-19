using MediatR;
using SplitFlow.Application.Commands.Gestion.ProductoCommands;
using SplitFlow.Domain.Entities.Gestion;
using SplitFlow.Domain.Events.Gestion;
using SplitFlow.Domain.Events.Parametrizacion;
using SplitFlow.Domain.Events.Perfilamiento;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Parametrizacion;

namespace SplitFlow.Application.Handlers.Gestion.ProductoHandlers
{
    public class ProductoCommandHandler : IRequestHandler<CreateProductoCommand, long>
    {
        private readonly IMediator _mediator;
        private readonly IParGenYEspeRepository _parGenYEspeRepository;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IProductoRepository _productoRepository;

        public ProductoCommandHandler(
            IMediator mediator,
            IParGenYEspeRepository parGenYEspeRepository,
            ICuentaRepository cuentaRepository,
            IProductoRepository productoRepository)
        {
            _mediator = mediator;
            _parGenYEspeRepository = parGenYEspeRepository;
            _cuentaRepository = cuentaRepository;
            _productoRepository = productoRepository;
        }

        public async Task<long> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            var tipoProducto = await _parGenYEspeRepository.GetParEspecificoById(request.TipoProductoId);
            var cuenta = await _cuentaRepository.GetCuentaById(request.CuentaId);

            var producto = new Producto
            {
                IdCuenta = request.CuentaId,
                IdTipoProducto = request.TipoProductoId,
                Nombre = request.Nombre,
                NumeroProducto = request.NumeroProducto,
                FechaVencimiento = request.FechaVencimiento,
                IsActive = request.IsActive,
                Saldo = request.Saldo,
                LimiteCredito = request.LimiteCredito,
                SaldoDisponible = request.SaldoDisponible,
                TasaInteresanual = request.TasaInteresAnual,
                FechaCorte = request.FechaCorte,
                FechaLimitePago = request.FechaLimitePago,
                CreateAt = DateTime.Now
            };

            await _productoRepository.AddProducto(producto);

            await _mediator.Publish(new ProductoCreatedEvent
            {
                ProductoId = producto.Id,
                Cuenta = new CuentaCreatedEvent
                {
                    CuentaId = cuenta.Id,
                    Usuario = new UserCreatedEvent
                    {
                        UserId = cuenta.Usuario.Id,
                        Username = cuenta.Usuario.Username
                    },
                    TipoCuenta = new ParEspecificoCreatedEvent
                    {
                        ParEspeId = cuenta.TipoCuenta.Id,
                        Nombre = cuenta.TipoCuenta.Nombre
                    },
                    Banco = new ParEspecificoCreatedEvent
                    {
                        ParEspeId = cuenta.Banco.Id,
                        Nombre = cuenta.Banco.Nombre
                    },
                    NombreCuenta = cuenta.NombreCuenta,
                    Moneda = new ParEspecificoCreatedEvent
                    {
                        ParEspeId = cuenta.Moneda.Id,
                        Nombre = cuenta.Moneda.Nombre
                    },
                    Estado = cuenta.Estado
                },
                TipoProducto = new ParEspecificoCreatedEvent
                {
                    ParEspeId = tipoProducto.Id,
                    Nombre = tipoProducto.Nombre
                },
                Nombre = producto.Nombre,
                NumeroProducto = producto.NumeroProducto,
                FechaVencimiento = producto.FechaVencimiento,
                IsActive = producto.IsActive,
                Saldo = producto.Saldo,
                LimiteCredito = producto.LimiteCredito,
                SaldoDisponible = producto.SaldoDisponible,
                TasaInteresanual = producto.TasaInteresanual,
                FechaCorte = producto.FechaCorte,
                FechaLimitePago = producto.FechaLimitePago,
                CreateAt = producto.CreateAt,
                LastUpdate = producto.LastUpdate

            });

            return producto.Id;
        }
    }
}
