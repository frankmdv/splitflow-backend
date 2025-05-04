using MediatR;
using SplitFlow.Domain.Events.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Events.Gestion
{
    public class MovimientoCreditoCreatedEvent : INotification
    {
        public long MovCredId { get; set; }
        public CreditoCreatedEvent Credito { get; set; }
        public ParEspecificoCreatedEvent TipoMovimiento { get; set; }
        public string Monto { get; set; }
        public string? SaldoRestante { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public CuotaCreatedEvent? Cuota { get; set; }
    }
}
