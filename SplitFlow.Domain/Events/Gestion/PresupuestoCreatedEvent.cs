using MediatR;
using SplitFlow.Domain.Events.Parametrizacion;
using SplitFlow.Domain.Events.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Events.Gestion
{
    public class PresupuestoCreatedEvent : INotification
    {
        public long PresupuestoId { get; set; }
        public UserCreatedEvent Usuario { get; set; }
        public ParEspecificoCreatedEvent Categoria { get; set; }
        public string MontoAsignado { get; set; }
        public bool Activo { get; set; }
    }
}
