using MediatR;
using SplitFlow.Domain.Entities.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Events.Perfilamiento
{
    public class RolModuloCreatedEvent : INotification
    {
        public long Id { get; set; }
        public RoleCreatedEvent Role { get; set; }
        public ModuloCreatedEvent Modulo { get; set; }
    }
}
