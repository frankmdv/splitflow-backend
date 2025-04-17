using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Parametrizacion.ParEspe
{
    public class GetParEspByIdQuery : IRequest<ParEspecificoReadModel>
    {
        public long ParEspeId { get; set; }

        public GetParEspByIdQuery(long parEspeId)
        {
            ParEspeId = parEspeId;
        }   
    }
}
