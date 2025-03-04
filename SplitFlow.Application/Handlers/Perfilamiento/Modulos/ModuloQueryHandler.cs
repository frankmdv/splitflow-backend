using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Perfilamiento.Modulos;
using SplitFlow.Application.Queries.Perfilamiento.Roles;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Perfilamiento.Modulos
{
    public class ModuloQueryHandler :
    IRequestHandler<GetAllModulosQuery, List<ModuloReadModel>>,
    IRequestHandler<GetModuloByIdQuery, ModuloReadModel>
    {
        private readonly IMongoCollection<ModuloReadModel> _modulos;

        public ModuloQueryHandler(IMongoDatabase database)
        {
            _modulos = database.GetCollection<ModuloReadModel>("Modules");
        }

        public async Task<List<ModuloReadModel>> Handle(GetAllModulosQuery request, CancellationToken cancellationToken)
        {
            return await _modulos.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<ModuloReadModel> Handle(GetModuloByIdQuery request, CancellationToken cancellationToken)
        {
            return await _modulos.Find(u => u.Id == request.ModuloId).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
