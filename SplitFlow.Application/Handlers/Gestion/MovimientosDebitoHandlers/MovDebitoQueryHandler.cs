using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Gestion.MovimientoDebitoQuerys;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Gestion.MovimientosDebitoHandlers
{
    public class MovDebitoQueryHandler : 
    IRequestHandler<GetAllMovimientosDebitoQuery, List<MovimientoDebitoReadModel>>,
    IRequestHandler<GetMovimientosByIdProducto, List<MovimientoDebitoReadModel>>,
    IRequestHandler<GetMovimientoDebitoByIdQuery, MovimientoDebitoReadModel>
    {
        private readonly IMongoCollection<MovimientoDebitoReadModel> _movDeb;

        public MovDebitoQueryHandler(IMongoDatabase database)
        {
            _movDeb = database.GetCollection<MovimientoDebitoReadModel>("MovimientoDebito");
        }

        public async Task<List<MovimientoDebitoReadModel>> Handle(GetAllMovimientosDebitoQuery request, CancellationToken cancellationToken)
        {
            return await _movDeb.Find(_ => true).ToListAsync(cancellationToken);

        }

        public async Task<List<MovimientoDebitoReadModel>> Handle(GetMovimientosByIdProducto request, CancellationToken cancellationToken)
        {
            return await _movDeb.Find(m => m.Producto.Id == request.IdProducto).ToListAsync(cancellationToken);
        }

        public async Task<MovimientoDebitoReadModel> Handle(GetMovimientoDebitoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _movDeb.Find(m => m.Id == request.IdMovimientoDebito).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
