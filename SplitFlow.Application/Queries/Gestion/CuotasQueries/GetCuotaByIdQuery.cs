using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.CuotasQueries
{
    public class GetCuotaByIdQuery : IRequest<CuotaReadModel>
    {
        public long IdCuota { get; set; }

        public GetCuotaByIdQuery(long idCuota)
        {
            IdCuota = idCuota;
        }
    }
}
