using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Perfilamiento.Users
{
    public class GetAllUsersQuery : IRequest<List<UserReadModel>>
    {
    }
}
