using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Perfilamiento.Roles;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Perfilamiento.Roles
{
    public class RoleQueryHandler :
    IRequestHandler<GetAllRolesQuery, List<RoleReadModel>>,
    IRequestHandler<GetRoleByIdQuery, RoleReadModel>
    {
        private readonly IMongoCollection<RoleReadModel> _roles;

        public RoleQueryHandler(IMongoDatabase database)
        {
            _roles = database.GetCollection<RoleReadModel>("Roles");
        }

        public async Task<List<RoleReadModel>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return await _roles.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<RoleReadModel> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _roles.Find(u => u.Id == request.RoleId).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
