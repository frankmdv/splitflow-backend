using MediatR;
using MongoDB.Driver;
using SplitFlow.Domain.Events;
using SplitFlow.Infrastructure.MongoDB.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.EventHandlers
{
    public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly IMongoCollection<UserReadModel> _users;

        public UserCreatedEventHandler(IMongoDatabase database)
        {
            _users = database.GetCollection<UserReadModel>("Users");
        }

        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            var user = new UserReadModel
            {
                Id = notification.UserId,
                Name = notification.Name,
                Email = notification.Email
            };

            await _users.InsertOneAsync(user);
        }
    }
}
