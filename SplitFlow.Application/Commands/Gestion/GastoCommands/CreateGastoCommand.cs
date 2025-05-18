using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Commands.Gestion.GastoCommands
{
    public class CreateGastoCommand : IRequest<long>
    {
        public long PresupuestoId { get; set; }
        public long? MovimientoDebitoId { get; set; }
        public long? MovimientoCreditoId { get; set; }
        public string Monto { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaGasto { get; set; }
    }
}
