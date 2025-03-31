using SplitFlow.Domain.Entities.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Entities.Gestion
{
    public class MovimientoDebito
    {
        public long Id { get; set; }
        public long IdProducto { get; set; }
        public virtual Producto Producto { get; set; }
        public long IdTipoMovimiento { get; set; }
        public virtual ParametroEspecifico TipoMovimiento { get; set; }
        public string Monto { get; set; }
        public string SaldoPrevio { get; set; }
        public string SaldoPosterior { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}
