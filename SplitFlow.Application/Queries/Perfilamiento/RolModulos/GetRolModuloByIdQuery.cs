using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Perfilamiento.RolModulo
{
    public class GetRolModuloByIdQuery : IRequest<RolModuloReadModel>
    {
        public long RolModuloId { get; set; }

        public GetRolModuloByIdQuery(long rolModuloId)
        {
            RolModuloId = rolModuloId;
        }
    }
}
