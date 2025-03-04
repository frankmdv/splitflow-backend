using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Perfilamiento.Roles
{
    public class GetRoleByIdQuery : IRequest<RoleReadModel>
    {
        public long RoleId { get; set; }

        public GetRoleByIdQuery(long roleId)
        {
            RoleId = roleId;
        }
    }
}
