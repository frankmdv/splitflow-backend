using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Gestion.MovimientoCreditoQueries;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Gestion.MovimientosCreditoHandlers
{
    public class MovCreditoQueryHandler :
        IRequestHandler<GetAllMovimientosCreditosQuery, List<MovimientoCreditoReadModel>>,
        IRequestHandler<GetMovimientosCreditoByIdCreditoQuery, List<MovimientoCreditoReadModel>>,
        IRequestHandler<GetMovimientoCreditoById, MovimientoCreditoReadModel>

    {
        private readonly IMongoCollection<MovimientoCreditoReadModel> _movCred;

        public MovCreditoQueryHandler(IMongoDatabase database)
        {
            _movCred = database.GetCollection<MovimientoCreditoReadModel>("MovimientoCredito");
        }

        public async Task<List<MovimientoCreditoReadModel>> Handle(GetAllMovimientosCreditosQuery request, CancellationToken cancellationToken)
        {
            return await _movCred.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<List<MovimientoCreditoReadModel>> Handle(GetMovimientosCreditoByIdCreditoQuery request, CancellationToken cancellationToken)
        {
            return await _movCred.Find(m => m.Credito.Id == request.IdCredito).ToListAsync(cancellationToken);
        }

        public async Task<MovimientoCreditoReadModel> Handle(GetMovimientoCreditoById request, CancellationToken cancellationToken)
        {
            return await _movCred.Find(m => m.Id == request.IdMovCred).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
