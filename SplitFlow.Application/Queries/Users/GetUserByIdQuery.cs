using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Users
{
    public class GetUserByIdQuery : IRequest<UserReadModel>
    {
        public long UserId { get; set; }

        public GetUserByIdQuery(long userId)
        {
            UserId = userId;
        }
    }
}
