using MediatR;
using MongoDB.Driver;
using SplitFlow.Domain.Events.Perfilamiento;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.EventHandlers.Perfilamiento
{
    public class RolModuloCreatedEventHandler : INotificationHandler<RolModuloCreatedEvent>
    {
        private readonly IMongoCollection<RolModuloReadModel> _rolModulo;
        
        public RolModuloCreatedEventHandler(IMongoDatabase database)
        {
            _rolModulo = database.GetCollection<RolModuloReadModel>("RolModulo");
        }

        public async Task Handle(RolModuloCreatedEvent notification, CancellationToken cancellationToken)
        {
            var rolModulo = new RolModuloReadModel
            {
                Id = notification.Id,
                Role = new RoleReadModel
                {
                    Id = notification.Role.RoleId,
                    Name = notification.Role.Name,
                    Description = notification.Role.Description
                },
                Modulo = new ModuloReadModel
                {
                    Id = notification.Modulo.Id,
                    Name = notification.Modulo.Name,
                    Level = notification.Modulo.Level,
                    Type = notification.Modulo.Type,
                    CreateAt = notification.Modulo.CreateAt
                }
            };

            await _rolModulo.InsertOneAsync(rolModulo, cancellationToken: cancellationToken);
        }
    }
}
