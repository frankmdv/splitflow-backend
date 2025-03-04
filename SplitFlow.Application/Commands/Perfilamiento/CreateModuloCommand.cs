using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Commands.Perfilamiento
{
    public class CreateModuloCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public string Type { get; set; }
    }
}
