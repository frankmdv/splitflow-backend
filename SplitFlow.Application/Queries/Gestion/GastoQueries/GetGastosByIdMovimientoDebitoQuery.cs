using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.GastoQueries
{
    public class GetGastosByIdMovimientoDebitoQuery : IRequest<List<GastoReadModel>>
    {
        public long IdMovimientodebito { get; set; }

        public GetGastosByIdMovimientoDebitoQuery(long idMovimientodebito)
        {
            IdMovimientodebito = idMovimientodebito;
        }
    }
}
