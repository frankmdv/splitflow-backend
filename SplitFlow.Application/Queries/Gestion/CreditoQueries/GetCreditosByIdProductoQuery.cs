using MediatR;
using Microsoft.Identity.Client;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.CreditoQueries
{
    public class GetCreditosByIdProductoQuery : IRequest<List<CreditoReadModel>>
    {
        public long IdProducto { get; set; }

        public GetCreditosByIdProductoQuery(long idProducto)
        {
            IdProducto = idProducto;
        }
    }
}
