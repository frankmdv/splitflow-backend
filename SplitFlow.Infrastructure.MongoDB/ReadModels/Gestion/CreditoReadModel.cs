using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion
{
    public class CreditoReadModel
    {
        public long Id { get; set; }
        public ProductoReadModel Producto { get; set; }
        public string MontoTotal { get; set; }
        public string? SaldoPendiente { get; set; }
        public string? TasaInteres { get; set; }
        public DateTime FechaFin { get; set; }
        public ParEspecificoReadModel Estado { get; set; }
    }
}
