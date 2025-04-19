using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.ProductoQuerys
{
    public class GetAllProductosQuery : IRequest<List<ProductoReadModel>>
    {
    }
}
