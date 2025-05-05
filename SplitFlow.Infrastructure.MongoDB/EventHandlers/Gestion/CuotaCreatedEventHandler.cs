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
    public class CuotaCreatedEventHandler : INotificationHandler<CuotaCreatedEvent>
    {
        private readonly IMongoCollection<CuotaReadModel> _cuotas;

        public CuotaCreatedEventHandler(IMongoDatabase database)
        {
            _cuotas = database.GetCollection<CuotaReadModel>("Cuotas");
        }

        public async Task Handle(CuotaCreatedEvent notification, CancellationToken cancellationToken)
        {
            var cuota = new CuotaReadModel
            {
                Id = notification.CuotaId,
                Credito = new CreditoReadModel
                {
                    Id = notification.Credito.CreditoId,
                    Producto = new ProductoReadModel
                    {
                        Id = notification.Credito.Producto.ProductoId,
                        Nombre = notification.Credito.Producto.Nombre
                    },
                    MontoTotal = notification.Credito.MontoTotal,
                    SaldoPendiente = notification.Credito.SaldoPendiente
                },
                NumeroCuota = notification.NumeroCuota,
                MontoCuota = notification.MontoCuota,
                FechaVencimiento = notification.FechaVencimiento,
                Estado = new ParEspecificoReadModel
                {
                    Id = notification.Estado.ParEspeId,
                    Nombre = notification.Estado.Nombre
                }
            };

            await _cuotas.InsertOneAsync(cuota, cancellationToken: cancellationToken);
        }
    }
}
