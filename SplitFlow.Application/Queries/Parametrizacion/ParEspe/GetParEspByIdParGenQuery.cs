using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Parametrizacion.ParEspe
{
    public class GetParEspByIdParGenQuery : IRequest<List<ParEspecificoReadModel>>
    {
        public long IdParGen { get; set; }

        public GetParEspByIdParGenQuery(long idParGen)
        {
            IdParGen = idParGen;
        }
    }
}
