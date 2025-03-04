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
    public class RoleCreatedEventHandler : INotificationHandler<RoleCreatedEvent>
    {
        private readonly IMongoCollection<RoleReadModel> _roles;

        public RoleCreatedEventHandler(IMongoDatabase database)
        {
            _roles = database.GetCollection<RoleReadModel>("Roles");
        }

        public async Task Handle(RoleCreatedEvent notification, CancellationToken cancellationToken)
        {
            var role = new RoleReadModel
            {
                Id = notification.RoleId,
                Name = notification.Name,
                Description = notification.Description,
            };

            await _roles.InsertOneAsync(role, cancellationToken: cancellationToken);
        }
    }
}
