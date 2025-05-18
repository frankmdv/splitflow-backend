using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.GastoQueries
{
    public class GetGastoByIdQuery : IRequest<GastoReadModel>
    {
        public long IdGasto { get; set; }

        public GetGastoByIdQuery(long idGasto)
        {
            IdGasto = idGasto;
        }
    }
}
