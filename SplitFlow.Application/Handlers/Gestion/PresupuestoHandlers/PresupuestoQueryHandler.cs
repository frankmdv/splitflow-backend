using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Gestion.PresupuestoQueries;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Gestion.PresupuestoHandlers
{
    public class PresupuestoQueryHandler :
        IRequestHandler<GetAllPresupuestosQuery, List<PresupuestoReadModel>>,
        IRequestHandler<GetPresupuestosByIdUsuarioQuery, List<PresupuestoReadModel>>,
        IRequestHandler<GetPresupuestoByIdQuery, PresupuestoReadModel>
    {
        private readonly IMongoCollection<PresupuestoReadModel> _presupuesto;

        public PresupuestoQueryHandler(IMongoDatabase database)
        {
            _presupuesto = database.GetCollection<PresupuestoReadModel>("Presupuesto");
        }

        public async Task<List<PresupuestoReadModel>> Handle(GetAllPresupuestosQuery request, CancellationToken cancellationToken)
        {
            return await _presupuesto.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<List<PresupuestoReadModel>> Handle(GetPresupuestosByIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _presupuesto.Find(m => m.Usuario.Id == request.IdUsuario).ToListAsync(cancellationToken);
        }

        public async Task<PresupuestoReadModel> Handle(GetPresupuestoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _presupuesto.Find(m => m.Id == request.IdPresupuesto).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
