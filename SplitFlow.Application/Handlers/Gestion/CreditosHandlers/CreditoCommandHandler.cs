using MediatR;
using SplitFlow.Application.Commands.Gestion.CreditoCommands;
using SplitFlow.Domain.Events.Gestion;
using SplitFlow.Domain.Events.Parametrizacion;
using SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Gestion.CreditosHandlers
{
    public class CreditoCommandHandler : IRequestHandler<CreateCreditoCommand, long>
    {
        private readonly ICreditoRepository _creditoRepository;
        private readonly IParGenYEspeRepository _parGenYEspeRepository;
        private readonly IMediator _mediator;
        private readonly IProductoRepository _productoRepository;

        public CreditoCommandHandler(
            ICreditoRepository creditoRepository, 
            IParGenYEspeRepository parGenYEspeRepository, 
            IMediator mediator,
            IProductoRepository productoRepository)
        {
            _creditoRepository = creditoRepository;
            _parGenYEspeRepository = parGenYEspeRepository;
            _mediator = mediator;
            _productoRepository = productoRepository;
        }

        public async Task<long> Handle(CreateCreditoCommand request, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.GetProductoById(request.ProductoId);
            var estado = await _parGenYEspeRepository.GetParEspecificoById(request.EstadoId);

            var credito = new Credito
            {
                IdProducto = request.ProductoId,
                MontoTotal = request.MontoTotal,
                SaldoPendiente = request.SaldoPendiente,
                TasaInteres = request.TasaInteres,
                FechaFin = request.FechaFin,
                IdEstado = request.EstadoId
            };

            await _creditoRepository.AddCredito(credito);

            await _mediator.Publish(new CreditoCreatedEvent
            {
                CreditoId = credito.Id,
                Producto = new ProductoCreatedEvent
                {
                    ProductoId = producto.Id,
                    Nombre = producto.Nombre
                },
                MontoTotal = request.MontoTotal,
                SaldoPendiente = request.SaldoPendiente,
                TasaInteres = request.TasaInteres,
                FechaFin = request.FechaFin,
                Estado = new ParEspecificoCreatedEvent
                {
                    ParEspeId = estado.Id,
                    Nombre = estado.Nombre
                }
            });

            return credito.Id;
        }
    }
}
