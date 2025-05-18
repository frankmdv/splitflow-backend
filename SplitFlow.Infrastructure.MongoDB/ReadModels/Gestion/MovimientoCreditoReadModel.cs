using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion
{
    public class MovimientoCreditoReadModel
    {
        public long Id { get; set; }
        public CreditoReadModel Credito { get; set; }
        public ParEspecificoReadModel TipoMovimiento { get; set; }
        public string Monto { get; set; }
        public string SaldoRestante { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}
