using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Commands.Perfilamiento
{
    public class CreateRoleCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
