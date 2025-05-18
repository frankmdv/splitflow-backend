using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.GastoQueries
{
    public class GetGastoByIdMovimientoCreditoQuery : IRequest<List<GastoReadModel>>
    {
        public long IdMovimientoCredito { get; set; }

        public GetGastoByIdMovimientoCreditoQuery(long idMovimientoCredito)
        {
            IdMovimientoCredito = idMovimientoCredito;
        }
    }
}
