using SplitFlow.Domain.Entities.Parametrizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion
{
    [Table("Cuota", Schema = "GES")]
    public class Cuota
    {
        public long Id { get; set; }

        public long IdCredito { get; set; }
        public virtual Credito Credito { get; set; }

        public int NumeroCuota { get; set; }
        public string MontoCuota { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public long IdEstado { get; set; }
        public virtual ParametroEspecifico Estado { get; set; }

        public List<MovimientoCredito> ListaMovimientosCredito { get; set; } = new(); // Pagos parciales a esta cuota
    }

}
