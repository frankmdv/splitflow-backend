using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Commands.Gestion.CuentaCommands
{
    public class CreateCuentaCommand : IRequest<long>
    {
        public long UsuarioId { get; set; }
        public long TipoCuentaId { get; set; }
        public long BancoId { get; set; }
        public string NombreCuenta { get; set; }
        public long MonedaId { get; set; }
        public bool Estado { get; set; }
    }
}
