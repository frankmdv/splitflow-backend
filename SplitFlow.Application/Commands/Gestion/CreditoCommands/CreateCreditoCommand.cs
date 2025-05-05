using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Commands.Gestion.CreditoCommands
{
    public  class CreateCreditoCommand : IRequest<long>
    {
        public long ProductoId { get; set; }
        public string MontoTotal { get; set; }
        public string? SaldoPendiente { get; set; }
        public string? TasaInteres { get; set; }
        public DateTime FechaFin { get; set; }
        public long EstadoId { get; set; }
    }
}
