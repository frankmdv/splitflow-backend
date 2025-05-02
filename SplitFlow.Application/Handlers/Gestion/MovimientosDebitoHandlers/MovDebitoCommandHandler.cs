using MediatR;
using SplitFlow.Application.Commands.Gestion.MovimientoDebitoCommands;
using SplitFlow.Domain.Entities.Gestion;
using SplitFlow.Domain.Events.Gestion;
using SplitFlow.Domain.Events.Parametrizacion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Gestion.MovimientosDebitoHandlers
{
    public class MovDebitoCommandHandler : IRequestHandler<CreateMovimientoDebitoCommand, long>
    {
        private readonly IMediator _mediator;
        private readonly IParGenYEspeRepository _parGenYEspeRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IMovimientoDebitoRepository _movimientoDebitoRepository;

        public MovDebitoCommandHandler(
            IMediator mediator,
            IParGenYEspeRepository parGenYEspeRepository,
            IProductoRepository productoRepository,
            IMovimientoDebitoRepository movimientoDebitoRepository)
        {
            _mediator = mediator;
            _movimientoDebitoRepository = movimientoDebitoRepository;
            _parGenYEspeRepository = parGenYEspeRepository;
            _productoRepository = productoRepository;
        }

        public async Task<long> Handle(CreateMovimientoDebitoCommand request, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.GetProductoById(request.ProductoId);
            var tipoMovimiento = await _parGenYEspeRepository.GetParEspecificoById(request.TipoMovimientoId);

            var MovDeb = new MovimientoDebito
            {
                IdProducto = request.ProductoId,
                IdTipoMovimiento = request.TipoMovimientoId,
                Monto = request.Monto,
                SaldoPrevio = request.SaldoPrevio,
                SaldoPosterior = request.SaldoPosterior,
                FechaMovimiento = DateTime.Now,
            };

            await _movimientoDebitoRepository.AddMovimientoDebito(MovDeb);

            await _mediator.Publish(new MovimientoDebitoCreatedEvent
            {
                MovDebiId = MovDeb.Id,
                Producto = new ProductoCreatedEvent
                {
                    ProductoId = producto.Id,
                    NumeroProducto = producto.NumeroProducto,
                },
                TipoMovimiento = new ParEspecificoCreatedEvent
                {
                    ParEspeId = tipoMovimiento.Id,
                    Nombre = tipoMovimiento.Nombre,
                },
                Monto = MovDeb.Monto,
                SaldoPrevio = MovDeb.SaldoPrevio,
                SaldoPosterior = MovDeb.SaldoPosterior,
                FechaMovimiento = MovDeb.FechaMovimiento,
            });

            return MovDeb.Id;
        }
    }
}
