using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Perfilamiento.Modulos;
using SplitFlow.Application.Queries.Perfilamiento.RolModulo;
using SplitFlow.Application.Queries.Perfilamiento.RolModulos;
using SplitFlow.Application.Queries.Perfilamiento.Users;
using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Perfilamiento.RolModulos
{
    public class RolModuloQueryHandler :
    IRequestHandler<GetAllRolModulosQuery, List<RolModuloReadModel>>,
    IRequestHandler<GetRolModuloByIdQuery, RolModuloReadModel>,
    IRequestHandler<GetRolModuloByIdRol, RolModuloReadModel>,
    IRequestHandler<GetModulosByIdRoleQuery, List<ModuloReadModel>>
    {
        private readonly IMongoCollection<RolModuloReadModel> _rolModulo;

        public RolModuloQueryHandler(IMongoDatabase database)
        {
            _rolModulo = database.GetCollection<RolModuloReadModel>("RolModulo");
        }

        public async Task<List<RolModuloReadModel>> Handle(GetAllRolModulosQuery request, CancellationToken cancellationToken)
        {
            return await _rolModulo.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<RolModuloReadModel> Handle(GetRolModuloByIdQuery request, CancellationToken cancellationToken)
        {
            return await _rolModulo.Find(u => u.Id == request.RolModuloId).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<RolModuloReadModel> Handle(GetRolModuloByIdRol request, CancellationToken cancellationToken)
        {
            return await _rolModulo.Find(r => r.Role.Id == request.RolId).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<ModuloReadModel>> Handle(GetModulosByIdRoleQuery request, CancellationToken cancellationToken)
        {
            var rolModulos = await _rolModulo
                .Find(rm => rm.Role.Id == request.RoleId)
                .ToListAsync(cancellationToken);

            var modulos = rolModulos
                .Select(rm => rm.Modulo)
                .GroupBy(m => m.Id) // Alternativa a DistinctBy para compatibilidad
                .Select(g => g.First())
                .ToList();

            return modulos;
        }
    }
}
