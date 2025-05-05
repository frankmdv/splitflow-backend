using MediatR;
using MongoDB.Driver;
using SplitFlow.Domain.Events.Gestion;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.EventHandlers.Gestion
{
    public class PresupuestoCreatedEventHandler : INotificationHandler<PresupuestoCreatedEvent>
    {
        private readonly IMongoCollection<PresupuestoReadModel> _presupuesto;

        public PresupuestoCreatedEventHandler(IMongoDatabase database)
        {
            _presupuesto = database.GetCollection<PresupuestoReadModel>("Presupuesto");
        }

        public async Task Handle(PresupuestoCreatedEvent notification, CancellationToken cancellationToken)
        {
            var presupuesto = new PresupuestoReadModel
            {
                Id = notification.PresupuestoId,
                Usuario = new UserReadModel
                {
                    Id = notification.Usuario.UserId,
                    Username = notification.Usuario.Username,
                    Email = notification.Usuario.Email,
                    IsActive = notification.Usuario.IsActive
                },
                Categoria = new ParEspecificoReadModel
                {
                    Id = notification.Categoria.ParEspeId,
                    Nombre = notification.Categoria.Nombre,
                    Estado = notification.Categoria.Estado,
                },
                MontoAsignado = notification.MontoAsignado,
                Activo = notification.Activo
            };

            await _presupuesto.InsertOneAsync(presupuesto, cancellationToken: cancellationToken);
        }
    }
}
