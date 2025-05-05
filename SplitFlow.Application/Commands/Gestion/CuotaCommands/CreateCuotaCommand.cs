using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace SplitFlow.Application.Commands.Gestion.CuotaCommands
{
    public class CreateCuotaCommand : IRequest<long>
    {
        public long CreditoId { get; set; }
        public int NumeroCuota { get; set; }
        public string MontoCuota { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public long EstadoId { get; set; }
    }
}
