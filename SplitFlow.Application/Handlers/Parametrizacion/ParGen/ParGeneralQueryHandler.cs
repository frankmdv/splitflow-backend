using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Parametrizacion.ParEspe;
using SplitFlow.Application.Queries.Parametrizacion.ParGen;
using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Parametrizacion.ParGen
{
    public class ParGeneralQueryHandler :
    IRequestHandler<GetAllParGenQuery, List<ParGeneralReadModel>>,
    IRequestHandler<GetParGenByIdQuery, ParGeneralReadModel>
    {
        private readonly IMongoCollection<ParGeneralReadModel> _parGens;

        public ParGeneralQueryHandler(IMongoDatabase database)
        {
            _parGens = database.GetCollection<ParGeneralReadModel>("ParametroGeneral");
        }

        public async Task<List<ParGeneralReadModel>> Handle(GetAllParGenQuery request, CancellationToken cancellationToken)
        {
            return await _parGens.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<ParGeneralReadModel> Handle(GetParGenByIdQuery request, CancellationToken cancellationToken)
        {
            return await _parGens.Find(p => p.Id == request.ParGenId).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
