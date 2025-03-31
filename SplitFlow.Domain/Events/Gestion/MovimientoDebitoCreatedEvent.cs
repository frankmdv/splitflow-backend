using MediatR;
using SplitFlow.Domain.Events.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Events.Gestion
{
    public class MovimientoDebitoCreatedEvent : INotification
    {
        public long MovDebiId { get; set; }
        public ProductoCreatedEvent Producto { get; set; }
        public ParEspecificoCreatedEvent TipoMovimiento { get; set; }
        public string Monto { get; set; }
        public string SaldoPrevio { get; set; }
        public string SaldoPosterior { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}
