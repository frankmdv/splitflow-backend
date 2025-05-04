using SplitFlow.Domain.Entities.Parametrizacion;
using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Entities.Gestion
{
    [Table("Gasto", Schema = "GES")]
    public class Gasto
    {
        public long Id { get; set; }
        public long IdPresupuesto { get; set; }
        public virtual Presupuesto Presupuesto { get; set; }
        //Si el gasto se genera desde un producto debito
        public long? IdMovimientoDebito { get; set; }
        public virtual MovimientoDebito? MovimientoDebito { get; set; }
        //Si el gasto se genera desde un producto credito
        public long? IdMovimientoCredito { get; set; }
        public virtual MovimientoCredito? MovimientoCredito { get; set; }
        public string Monto { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaGAsto { get; set; }
    }
}
