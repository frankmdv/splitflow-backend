using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Queries.Perfilamiento.RolModulo
{
    public class GetAllRolModulosQuery : IRequest<List<RolModuloReadModel>>
    {
    }
}
