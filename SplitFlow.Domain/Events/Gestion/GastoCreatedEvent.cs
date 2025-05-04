using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Events.Gestion
{
    public class GastoCreatedEvent : INotification
    {
        public long GastoId { get; set; }
        public PresupuestoCreatedEvent Presupuesto { get; set; }
        public MovimientoDebitoCreatedEvent? MovimientoDebito { get; set; }
        public MovimientoCreditoCreatedEvent? MovimientoCredito { get; set; }
        public string Monto { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaGAsto { get; set; }
    }
}
