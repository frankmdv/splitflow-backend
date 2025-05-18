using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Commands.Gestion.MovimientoCreditoCommands
{
    public class CreateMovimientoCreditoCommand : IRequest<long>
    {
        public long CreditoId { get; set; }
        public long TipoMovimientoId { get; set; }
        public string Monto { get; set; }
        public string? SaldoRestante { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}
