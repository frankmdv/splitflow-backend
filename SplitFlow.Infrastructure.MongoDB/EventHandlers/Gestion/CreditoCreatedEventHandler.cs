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
    public class CreditoCreatedEventHandler : INotificationHandler<CreditoCreatedEvent>
    {
        private readonly IMongoCollection<CreditoReadModel> _credito;

        public CreditoCreatedEventHandler(IMongoDatabase database)
        {
            _credito = database.GetCollection<CreditoReadModel>("Credito");
        }
        public async Task Handle(CreditoCreatedEvent notification, CancellationToken cancellationToken)
        {
            var credito = new CreditoReadModel
            {
                Id = notification.CreditoId,
                Producto = new ProductoReadModel
                {
                    Id = notification.Producto.ProductoId,
                    NumeroProducto = notification.Producto.NumeroProducto,
                    CreateAt = notification.Producto.CreateAt,
                },
                MontoTotal = notification.MontoTotal,
                SaldoPendiente = notification.SaldoPendiente,
                TasaInteres = notification.TasaInteres,
                FechaFin = notification.FechaFin,
                Estado = new ParEspecificoReadModel
                {
                    Id = notification.Estado.ParEspeId,
                    Nombre = notification.Estado.Nombre
                }
            };

            await _credito.InsertOneAsync(credito, cancellationToken: cancellationToken);
        }
    }
}
