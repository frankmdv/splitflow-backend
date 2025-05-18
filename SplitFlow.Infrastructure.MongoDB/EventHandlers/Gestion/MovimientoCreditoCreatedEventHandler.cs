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
    public class MovimientoCreditoCreatedEventHandler : INotificationHandler<MovimientoCreditoCreatedEvent>
    {
        private readonly IMongoCollection<MovimientoCreditoReadModel> _movCred;

        public MovimientoCreditoCreatedEventHandler(IMongoDatabase database)
        {
            _movCred = database.GetCollection<MovimientoCreditoReadModel>("MovimientoCredito");
        }
        public async Task Handle(MovimientoCreditoCreatedEvent notification, CancellationToken cancellationToken)
        {
            var movCredito = new MovimientoCreditoReadModel
            {
                Id = notification.MovCredId,
                Credito = new CreditoReadModel
                {
                    Id = notification.Credito.CreditoId,
                },
                TipoMovimiento = new ParEspecificoReadModel
                {
                    Id = notification.TipoMovimiento.ParEspeId,
                    Nombre = notification.TipoMovimiento.Nombre,
                },
                Monto = notification.Monto,
                SaldoRestante = notification.SaldoRestante,
                FechaMovimiento = notification.FechaMovimiento
            };

            await _movCred.InsertOneAsync(movCredito, cancellationToken: cancellationToken);
        }
    }
}
