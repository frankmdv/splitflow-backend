using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.MovimientoCreditoQueries
{
    public class GetMovimientoCreditoById : IRequest<MovimientoCreditoReadModel>
    {
        public long IdMovCred {  get; set; }

        public GetMovimientoCreditoById(long idMovCred)
        {
            IdMovCred = idMovCred;
        }
    }
}
