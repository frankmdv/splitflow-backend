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
    public class ParGeneralCreatedEventHandler : INotificationHandler<ParGeneralCreatedEvent>
    {
        private readonly IMongoCollection<ParGeneralReadModel> _pGeneral;

        public ParGeneralCreatedEventHandler(IMongoDatabase database)
        {
            _pGeneral = database.GetCollection<ParGeneralReadModel>("ParametroGeneral");
        }

        public async Task Handle(ParGeneralCreatedEvent notification, CancellationToken cancellationToken)
        {
            var pGeneral = new ParGeneralReadModel
            {
                Id = notification.ParGenId,
                Nombre = notification.Nombre,
                Estado = notification.Estado,
                CreateAt = notification.CreateAt
            };

            await _pGeneral.InsertOneAsync(pGeneral, cancellationToken: cancellationToken);
        }
    }
}
