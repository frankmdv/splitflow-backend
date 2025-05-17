using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Gestion.CreditoQueries
{
    public class GetCreditoByIdQuery : IRequest<CreditoReadModel>
    {
        public long IdCredito { get; set; }

        public GetCreditoByIdQuery(long idCredito)
        {
            IdCredito = idCredito;
        }
    }
}
