using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Commands.Gestion.PresupuestoCommands
{
    public class CreatePresupuestoCommand : IRequest<long>
    {
        public long UsuarioId { get; set; }
        public long CategoriaId { get; set; }
        public string MontoAsignado { get; set; }
        public bool Activo { get; set; }
    }
}
