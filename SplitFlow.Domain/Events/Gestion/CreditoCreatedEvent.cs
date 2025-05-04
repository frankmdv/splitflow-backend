using MediatR;
using SplitFlow.Domain.Events.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Events.Gestion
{
    public class CreditoCreatedEvent : INotification
    {
        public long CreditoId { get; set; }
        public ProductoCreatedEvent Producto { get; set; }
        public string MontoTotal { get; set; }
        public string? TasaInteres { get; set; }
        public DateTime FechaFin { get; set; }
        public ParEspecificoCreatedEvent Estado { get; set; }
    }
}
