using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Gestion.CreditoQueries;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Gestion.CreditosHandlers
{
    public class CreditoQueryHandler :
        IRequestHandler<GetAllCreditosQuery, List<CreditoReadModel>>,
        IRequestHandler<GetCreditoByIdQuery, CreditoReadModel>,
        IRequestHandler<GetCreditosByIdProductoQuery, List<CreditoReadModel>>
    {
        private readonly IMongoCollection<CreditoReadModel> _creditos;

        public async Task<List<CreditoReadModel>> Handle(GetAllCreditosQuery request, CancellationToken cancellationToken)
        {
            return await _creditos.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<CreditoReadModel> Handle(GetCreditoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _creditos.Find(c => c.Id == request.IdCredito).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<CreditoReadModel>> Handle(GetCreditosByIdProductoQuery request, CancellationToken cancellationToken)
        {
            return await _creditos.Find(c => c.Producto.Id == request.IdProducto).ToListAsync(cancellationToken);
        }
    }
}
