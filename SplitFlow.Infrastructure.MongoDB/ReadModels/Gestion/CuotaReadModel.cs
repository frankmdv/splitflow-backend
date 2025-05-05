using SplitFlow.Domain.Events.Parametrizacion;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion
{
    public class CuotaReadModel
    {
        public long Id { get; set; }
        public CreditoReadModel Credito { get; set; }
        public int NumeroCuota { get; set; }
        public string MontoCuota { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public ParEspecificoReadModel Estado { get; set; }
    }
}
