using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Commands.Gestion.MovimientoDebitoCommands
{
    public class CreateMovimientoDebitoCommand : IRequest<long>
    {
        public long ProductoId { get; set; }
        public long TipoMovimientoId { get; set; }
        public string Monto { get; set; }
        public string SaldoPrevio { get; set; }
        public string SaldoPosterior { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}

