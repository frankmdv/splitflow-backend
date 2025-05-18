using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.MovimientoCreditoQueries
{
    public class GetMovimientosCreditoByIdCreditoQuery : IRequest<List<MovimientoCreditoReadModel>
    {
        public long IdCredito { get; set; }

        public GetMovimientosCreditoByIdCreditoQuery(long idCredito)
        {
            IdCredito = idCredito;
        }
    }
}
