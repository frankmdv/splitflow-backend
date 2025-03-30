using SplitFlow.Domain.Entities.Parametrizacion;
using SplitFlow.Domain.Entities.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Entities.Gestion
{
    public class Cuenta
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public User Usuario { get; set; }
        public long IdTipoCuenta { get; set; }
        public ParametroEspecifico TipoCuenta { get; set; }
        public long IdBanco { get; set; }
        public ParametroEspecifico Banco { get; set; }
        public string NombreCuenta { get; set; }
        public long IdMoneda { get; set; }
        public ParametroEspecifico Moneda { get; set; }
        public bool Estado { get; set; }

        public List<Producto> ListaProducto { get; set; } = new List<Producto>();
    }
}
