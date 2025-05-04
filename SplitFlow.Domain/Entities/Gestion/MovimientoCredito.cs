using SplitFlow.Domain.Entities.Gestion;
using SplitFlow.Domain.Entities.Parametrizacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion
{
    [Table("MovimientoCredito", Schema = "GES")]
    public class MovimientoCredito
    {
        public long Id { get; set; }

        public long IdCredito { get; set; }
        public virtual Credito Credito { get; set; }

        public long IdTipoMovimiento { get; set; } // Abono capital, interés, comisión...
        public virtual ParametroEspecifico TipoMovimiento { get; set; }

        public string Monto { get; set; }
        public string? SaldoRestante { get; set; } // Después del movimiento

        public DateTime FechaMovimiento { get; set; }

        public long? IdCuota { get; set; } // Opcional: si aplica a una cuota
        public virtual Cuota? Cuota { get; set; }

        public List<Gasto> ListaGastoCredito { get; set; } = new List<Gasto>();
    }

}
