using MediatR;
using SplitFlow.Domain.Events.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Events.Gestion
{
    public class CuotaCreatedEvent : INotification
    {
        public long CuotaId { get; set; }
        public CreditoCreatedEvent Credito { get; set; }
        public int NumeroCuota { get; set; }
        public string MontoCuota { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public ParEspecificoCreatedEvent Estado { get; set; }
    }
}
