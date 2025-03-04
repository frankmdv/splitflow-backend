using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Commands.Perfilamiento
{
    public class CreateRolModuloCommand : IRequest<long>
    {
        public long RoleId { get; set; }
        public long ModuloId { get; set; }
    }
}
