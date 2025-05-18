using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.GastoQueries
{
    public class GetGastosByIdPresupuestoQuery : IRequest<List<GastoReadModel>>
    {
        public long IdPresupuesto { get; set; }

        public GetGastosByIdPresupuestoQuery(long idPresupuesto)
        {
            IdPresupuesto = idPresupuesto;
        }
    }
}
