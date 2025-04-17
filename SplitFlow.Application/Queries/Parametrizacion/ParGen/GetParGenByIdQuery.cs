using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Parametrizacion.ParGen
{
    public class GetParGenByIdQuery : IRequest<ParGeneralReadModel>
    {
        public long ParGenId { get; set; }

        public GetParGenByIdQuery(long parGenId)
        {
            ParGenId = parGenId;
        }
    }
}
