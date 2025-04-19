using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.ProductoQuerys
{
    public class GetProductoByIdCuenta : IRequest<List<ProductoReadModel>>
    {
        public long IdCuenta { get; set; }

        public GetProductoByIdCuenta(long idCuenta)
        {
            IdCuenta = idCuenta;
        }   
    }
}
