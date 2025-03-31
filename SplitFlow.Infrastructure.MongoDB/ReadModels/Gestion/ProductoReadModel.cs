using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion
{
    public class ProductoReadModel
    {
        public long Id { get; set; }
        public CuentaReadModel Cuenta { get; set; }
        public ParEspecificoReadModel TipoProducto { get; set; }
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
    }
}
