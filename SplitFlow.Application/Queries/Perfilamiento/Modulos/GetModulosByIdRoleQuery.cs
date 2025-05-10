using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Perfilamiento.Modulos
{
    public class GetModulosByIdRoleQuery : IRequest<List<ModuloReadModel>>
    {
        public long RoleId { get; set; }

        public GetModulosByIdRoleQuery(long roleId)
        {
            RoleId = roleId;
        }
    }
}
