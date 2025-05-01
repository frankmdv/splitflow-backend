using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Perfilamiento.Users;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Perfilamiento.Users
{
    public class UserQueryHandler :
    IRequestHandler<GetAllUsersQuery, List<UserWithoutPasswordDto>>,
    IRequestHandler<GetUserByIdQuery, UserWithoutPasswordDto>
    {
        private readonly IMongoCollection<UserReadModel> _users;

        public UserQueryHandler(IMongoDatabase database)
        {
            _users = database.GetCollection<UserReadModel>("Users");
        }

        public async Task<List<UserWithoutPasswordDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _users.Find(_ => true).ToListAsync(cancellationToken);
            return users.Select(MapToUserWithoutPassword).ToList();
        }

        public async Task<UserWithoutPasswordDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _users.Find(u => u.Id == request.UserId).FirstOrDefaultAsync(cancellationToken);
            return user == null ? null : MapToUserWithoutPassword(user);
        }

        private UserWithoutPasswordDto MapToUserWithoutPassword(UserReadModel user)
        {
            return new UserWithoutPasswordDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt
            };
        }
    }
}

