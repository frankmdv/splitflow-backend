using MediatR;
using MongoDB.Driver;
using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Domain.Events.Perfilamiento;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.EventHandlers.Perfilamiento
{
    public class ModuloCreatedEventHandler : INotificationHandler<ModuloCreatedEvent>
    {
        private readonly IMongoCollection<ModuloReadModel> _modules;

        public ModuloCreatedEventHandler(IMongoDatabase database)
        {
            _modules = database.GetCollection<ModuloReadModel>("Modules");
        }
        public async Task Handle(ModuloCreatedEvent notification, CancellationToken cancellationToken)
        {
            var module = new ModuloReadModel
            {
                Id = notification.Id,
                Name = notification.Name,
                Level = notification.Level,
                Type = notification.Type,
                CreateAt = DateTime.Now,
            };

            await _modules.InsertOneAsync(module, cancellationToken: cancellationToken);
        }
    }
}
