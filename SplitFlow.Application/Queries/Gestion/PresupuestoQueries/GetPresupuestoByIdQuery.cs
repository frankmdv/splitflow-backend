using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.PresupuestoQueries
{
    public class GetPresupuestoByIdQuery : IRequest<PresupuestoReadModel>
    {
        public long IdPresupuesto { get; set; }

        public GetPresupuestoByIdQuery(long idPresupuesto)
        {
            IdPresupuesto = idPresupuesto;
        }
    }
}
