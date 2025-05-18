using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.PresupuestoQueries
{
    public class GetPresupuestosByIdUsuarioQuery : IRequest<List<PresupuestoReadModel>>
    {
        public long IdUsuario { get; set; }

        public GetPresupuestosByIdUsuarioQuery(long idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }
}
