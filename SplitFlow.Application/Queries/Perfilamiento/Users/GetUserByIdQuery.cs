using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Perfilamiento.Users
{
    public class GetUserByIdQuery : IRequest<UserWithoutPasswordDto>
    {
        public long UserId { get; set; }

        public GetUserByIdQuery(long userId)
        {
            UserId = userId;
        }
    }
}
