using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.CuentasQuerys
{
    public class GetCuentasByIdUsuarioQuery : IRequest<List<CuentaReadModel>>
    {
        public long IdUsuario { get; set; }

        public GetCuentasByIdUsuarioQuery(long idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }
}
