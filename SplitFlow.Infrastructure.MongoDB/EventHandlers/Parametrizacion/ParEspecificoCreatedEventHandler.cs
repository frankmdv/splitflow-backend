using MediatR;
using MongoDB.Driver;
using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Domain.Events.Parametrizacion;
using SplitFlow.Domain.Events.Perfilamiento;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.EventHandlers.Parametrizacion
{
    public class ParEspecificoCreatedEventHandler : INotificationHandler<ParEspecificoCreatedEvent>
    {
        private readonly IMongoCollection<ParEspecificoReadModel> _pEspecifico;

        public ParEspecificoCreatedEventHandler(IMongoDatabase database)
        {
            _pEspecifico = database.GetCollection<ParEspecificoReadModel>("ParametroEspecifico");
        }

        public async Task Handle(ParEspecificoCreatedEvent notification, CancellationToken cancellationToken)
        {
            var pEspecifico = new ParEspecificoReadModel
            {
                Id = notification.ParEspeId,
                Nombre = notification.Nombre,
                Estado = notification.Estado,
                ParametroGeneral = new ParGeneralReadModel
                {
                    Id = notification.ParGeneral.ParGenId,
                    Nombre = notification.ParGeneral.Nombre,
                    Estado = notification.ParGeneral.Estado,
                    CreateAt = notification.ParGeneral.CreateAt
                },
                CreateAt = notification.CreateAt
            };

            await _pEspecifico.InsertOneAsync(pEspecifico, cancellationToken: cancellationToken);
        }
    }
}
