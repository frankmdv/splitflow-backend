using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Events.Parametrizacion
{
    public class ParGeneralCreatedEvent : INotification
    {
        public long ParGenId { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
