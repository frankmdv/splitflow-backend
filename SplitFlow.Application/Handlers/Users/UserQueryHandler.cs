using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Users;
using SplitFlow.Infrastructure.MongoDB.ReadModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Users
{
    public class UserQueryHandler :
    IRequestHandler<GetAllUsersQuery, List<UserReadModel>>,
    IRequestHandler<GetUserByIdQuery, UserReadModel>
    {
        private readonly IMongoCollection<UserReadModel> _users;

        public UserQueryHandler(IMongoDatabase database)
        {
            _users = database.GetCollection<UserReadModel>("Users");
        }

        public async Task<List<UserReadModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _users.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<UserReadModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _users.Find(u => u.Id == request.UserId).FirstOrDefaultAsync(cancellationToken);
        }
    }
}

