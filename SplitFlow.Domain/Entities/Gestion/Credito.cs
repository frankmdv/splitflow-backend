using SplitFlow.Domain.Entities.Gestion;
using SplitFlow.Domain.Entities.Parametrizacion;
using System.ComponentModel.DataAnnotations.Schema;

namespace SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion
{
    [Table("Credito", Schema = "GES")]
    public class Credito
    {
        public long Id { get; set; }

        public long IdProducto { get; set; }
        public virtual Producto Producto { get; set; }

        public string MontoTotal { get; set; }
        public string? SaldoPendiente { get; set; }

        public string? TasaInteres { get; set; }

        public DateTime FechaFin { get; set; }

        public long IdEstado { get; set; }
        public virtual ParametroEspecifico Estado { get; set; }

        public List<MovimientoCredito> ListaMovimientosCredito { get; set; } = new();
    }
}
