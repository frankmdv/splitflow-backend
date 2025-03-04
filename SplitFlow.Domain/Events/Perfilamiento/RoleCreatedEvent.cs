using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Events.Perfilamiento
{
    public class RoleCreatedEvent : INotification
    {
        public long RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
