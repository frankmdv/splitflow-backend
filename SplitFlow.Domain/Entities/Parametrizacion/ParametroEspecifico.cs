using SplitFlow.Domain.Entities.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Entities.Parametrizacion
{
    public class ParametroEspecifico
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public long IdParGeneral { get; set; }
        public virtual ParametroGeneral ParametroGeneral { get; set; }
        public DateTime CreateAt { get; set; }

        #region Cuenta
        public List<Cuenta> ListaTipoCuentaCuenta { get; set; } = new List<Cuenta>();
        public List<Cuenta> ListaBancoCuenta { get; set; } = new List<Cuenta>();
        public List<Cuenta> ListaMonedaCuenta { get; set; } = new List<Cuenta>();
        #endregion
        #region Producto
        public List<Producto> ListaTipoProducto { get; set; } = new List<Producto>();
        #endregion
        #region Movimiento Debito
        public List<MovimientoDebito> ListaTipoMovimientoDebito { get; set; } = new List<MovimientoDebito>();
        #endregion
        #region Presupuesto
        public List<Presupuesto> ListaCategoriasPresupuestos { get; set; } = new List<Presupuesto>();
        #endregion
    }
}
