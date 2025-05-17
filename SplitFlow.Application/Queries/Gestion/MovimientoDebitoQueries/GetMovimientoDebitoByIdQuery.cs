using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.MovimientoDebitoQueries
{
    public class GetMovimientoDebitoByIdQuery : IRequest<MovimientoDebitoReadModel>
    {
        public long IdMovimientoDebito { get; set; }

        public GetMovimientoDebitoByIdQuery(long idMovimientoDebito)
        {
            IdMovimientoDebito = idMovimientoDebito;
        }
    }
}
