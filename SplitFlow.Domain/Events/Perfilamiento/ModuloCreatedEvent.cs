using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Events.Perfilamiento
{
    public class ModuloCreatedEvent : INotification
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string Type { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
