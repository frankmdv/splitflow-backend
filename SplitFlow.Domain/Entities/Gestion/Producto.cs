using SplitFlow.Domain.Entities.Parametrizacion;
using SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Entities.Gestion
{
    [Table("Producto", Schema = "GES")]
    public class Producto
    {
        public long Id { get; set; }
        public long IdCuenta { get; set; }
        public Cuenta Cuenta { get; set; }
        public long IdTipoProducto { get; set; }
        public virtual ParametroEspecifico TipoProducto { get; set; }
        public string Nombre { get; set; }
        public string NumeroProducto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool IsActive { get; set; }
        public string? Saldo { get; set; } //Para productos debito
        public string? LimiteCredito { get; set; } // Para productos credito
        public string? SaldoDisponible { get; set; } // Para productos credito
        public string? TasaInteresanual { get; set; } // Para productos credito
        public DateTime? FechaCorte { get; set; } // Para productos credito
        public DateTime? FechaLimitePago { get; set; } // Para productos credito
        public DateTime CreateAt { get; set; }
        public DateTime? LastUpdate { get; set; }

        #region Movimiento Debito
        public List<MovimientoDebito> ListaMovimientoDebito { get; set; } = new List<MovimientoDebito>();
        #endregion
        #region credito
        public List<Credito> ListaCredito { get; set; } = new List<Credito>();
        #endregion
    }
}
