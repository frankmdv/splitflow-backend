using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Events.Parametrizacion
{
    public class ParEspecificoCreatedEvent : INotification
    {
        public long ParEspeId { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public ParGeneralCreatedEvent ParGeneral { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
