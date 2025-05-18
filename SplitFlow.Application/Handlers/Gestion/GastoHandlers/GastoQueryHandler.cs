using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Gestion.GastoQueries;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Gestion.GastoHandlers
{
    public class GastoQueryHandler :
        IRequestHandler<GetAllGastosQuery, List<GastoReadModel>>,
        IRequestHandler<GetGastoByIdQuery, GastoReadModel>,
        IRequestHandler<GetGastosByIdPresupuestoQuery, List<GastoReadModel>>,
        IRequestHandler<GetGastosByIdMovimientoDebitoQuery, List<GastoReadModel>>,
        IRequestHandler<GetGastoByIdMovimientoCreditoQuery, List<GastoReadModel>>
    {
        private readonly IMongoCollection<GastoReadModel> _gastos;

        public GastoQueryHandler(IMongoDatabase database)
        {
            _gastos = database.GetCollection<GastoReadModel>("Gastos");
        }

        public async Task<List<GastoReadModel>> Handle(GetAllGastosQuery request, CancellationToken cancellationToken)
        {
            return await _gastos.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<GastoReadModel> Handle(GetGastoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _gastos.Find(m => m.Id == request.IdGasto).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<GastoReadModel>> Handle(GetGastosByIdPresupuestoQuery request, CancellationToken cancellationToken)
        {
            return await _gastos.Find(m => m.Presupuesto.Id == request.IdPresupuesto).ToListAsync(cancellationToken);
        }

        public async Task<List<GastoReadModel>> Handle(GetGastosByIdMovimientoDebitoQuery request, CancellationToken cancellationToken)
        {
            return await _gastos.Find(m => m.MovimientoDebito.Id == request.IdMovimientodebito).ToListAsync(cancellationToken);
        }

        public async Task<List<GastoReadModel>> Handle(GetGastoByIdMovimientoCreditoQuery request, CancellationToken cancellationToken)
        {
            return await _gastos.Find(m => m.MovimientoCredito.Id == request.IdMovimientoCredito).ToListAsync(cancellationToken);
        }
    }
}
