using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Commands.Gestion.ProductoCommands
{
    public class CreateProductoCommand : IRequest<long>
    {
        public long CuentaId { get; set; }
        public long TipoProductoId { get; set; }
        public string Nombre { get; set; }
        public string NumeroProducto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool IsActive { get; set; }
        public string? Saldo { get; set; }
        public string? LimiteCredito { get; set; }
        public string? SaldoDisponible { get; set; }
        public string? TasaInteresAnual { get; set; }
        public DateTime? FechaCorte { get; set; }
        public DateTime? FechaLimitePago { get; set; }
    }
}
