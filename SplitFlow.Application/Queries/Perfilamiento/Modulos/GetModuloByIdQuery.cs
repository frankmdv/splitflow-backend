using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Perfilamiento.Modulos
{
    public class GetModuloByIdQuery : IRequest<ModuloReadModel>
    {
        public long ModuloId { get; set; }

        public GetModuloByIdQuery(long moduloId) 
        { 
            ModuloId = moduloId;
        }
    }
}
