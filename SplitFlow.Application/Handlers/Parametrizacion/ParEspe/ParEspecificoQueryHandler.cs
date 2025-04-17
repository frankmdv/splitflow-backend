using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Parametrizacion.ParEspe;
using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Parametrizacion.ParEspe
{
    public class ParEspecificoQueryHandler :
    IRequestHandler<GetAllParEspQuery, List<ParEspecificoReadModel>>,
    IRequestHandler<GetParEspByIdQuery, ParEspecificoReadModel>,
    IRequestHandler<GetParEspByIdParGenQuery, List<ParEspecificoReadModel>>
    {
        private readonly IMongoCollection<ParEspecificoReadModel> _parEspes;

        public ParEspecificoQueryHandler(IMongoDatabase database)
        {
            _parEspes = database.GetCollection<ParEspecificoReadModel>("ParametroEspecifico");
        }

        public async Task<List<ParEspecificoReadModel>> Handle(GetAllParEspQuery request, CancellationToken cancellationToken)
        {
            return await _parEspes.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<ParEspecificoReadModel> Handle(GetParEspByIdQuery request, CancellationToken cancellationToken)
        {
            return await _parEspes.Find(p => p.Id == request.ParEspeId).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<ParEspecificoReadModel>> Handle(GetParEspByIdParGenQuery request, CancellationToken cancellationToken)
        {
            return await _parEspes.Find(p => p.ParametroGeneral.Id == request.IdParGen).ToListAsync(cancellationToken);
        }
    }
}
