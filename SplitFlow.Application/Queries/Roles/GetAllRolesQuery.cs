using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Roles
{
    public class GetAllRolesQuery : IRequest<List<RoleReadModel>>
    {
    }
}
