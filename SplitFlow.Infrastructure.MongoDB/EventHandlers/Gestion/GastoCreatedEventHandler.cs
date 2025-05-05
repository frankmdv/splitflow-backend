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
    public class GastoCreatedEventHandler : INotificationHandler<GastoCreatedEvent>
    {
        private readonly IMongoCollection<GastoReadModel> _gastos;

        public GastoCreatedEventHandler(IMongoDatabase database)
        {
            _gastos = database.GetCollection<GastoReadModel>("Gastos");
        }
        public async Task Handle(GastoCreatedEvent notification, CancellationToken cancellationToken)
        {
            var gasto = new GastoReadModel
            {
                Id = notification.GastoId,
                Presupuesto = new PresupuestoReadModel
                {
                    Id = notification.Presupuesto.PresupuestoId,
                    Categoria = new ParEspecificoReadModel
                    {
                        Id = notification.Presupuesto.Categoria.ParEspeId,
                        Nombre = notification.Presupuesto.Categoria.Nombre
                    },
                    MontoAsignado = notification.Presupuesto.MontoAsignado,
                },
                MovimientoDebito = new MovimientoDebitoReadModel
                {
                    Id = notification.MovimientoDebito.MovDebiId,
                    Monto = notification.MovimientoDebito.Monto,
                },
                MovimientoCredito = new MovimientoCreditoReadModel
                {
                    Id = notification.MovimientoCredito.MovCredId,
                    Monto = notification.MovimientoCredito.Monto,
                },
                Monto = notification.Monto,
                Descripcion = notification.Descripcion,
                FechaGasto = notification.FechaGAsto
            };

            await _gastos.InsertOneAsync(gasto, cancellationToken: cancellationToken);
        }
    }
}
