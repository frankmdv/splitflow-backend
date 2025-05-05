using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion
{
    public class GastoReadModel
    {
        public long Id { get; set; }
        public PresupuestoReadModel Presupuesto { get; set; }
        public MovimientoDebitoReadModel? MovimientoDebito { get; set; }
        public MovimientoCreditoReadModel? MovimientoCredito { get; set; }
        public string Monto { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaGasto { get; set; }
    }
}
