using MediatR;
using MongoDB.Driver;
using SplitFlow.Domain.Events.Gestion;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.EventHandlers.Gestion
{
    public class MovimientoDebitoCreatedEventHandler : INotificationHandler<MovimientoDebitoCreatedEvent>
    {
        private readonly IMongoCollection<MovimientoDebitoReadModel> _movDebit;

        public MovimientoDebitoCreatedEventHandler(IMongoDatabase database)
        {
            _movDebit = database.GetCollection<MovimientoDebitoReadModel>("MovimientoDebito");
        }
        public async Task Handle(MovimientoDebitoCreatedEvent notification, CancellationToken cancellationToken)
        {
            var movDebt = new MovimientoDebitoReadModel
            {
                Id = notification.MovDebiId,
                Producto = new ProductoReadModel
                {
                    Id = notification.Producto.ProductoId,
                    Nombre = notification.Producto.Nombre,
                },
                TipoMovimiento = new ParEspecificoReadModel
                {
                    Id = notification.TipoMovimiento.ParEspeId,
                    Nombre = notification.TipoMovimiento.Nombre
                },
                Monto = notification.Monto,
                SaldoPrevio = notification.SaldoPrevio,
                SaldoPosterior = notification.SaldoPosterior,
                FechaMovimiento = notification.FechaMovimiento,
            };

            await _movDebit.InsertOneAsync(movDebt, cancellationToken: cancellationToken);
        }
    }
}
