using MediatR;
using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Domain.Events.Parametrizacion;
using SplitFlow.Domain.Events.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Events.Gestion
{
    public class CuentaCreatedEvent : INotification
    {
        public long CuentaId { get; set; }
        public UserCreatedEvent Usuario { get; set; }
        public ParEspecificoCreatedEvent TipoCuenta { get; set; }
        public ParEspecificoCreatedEvent Banco { get; set; }
        public string NombreCuenta { get; set; }
        public ParEspecificoCreatedEvent Moneda { get; set; }
        public bool Estado { get; set; }
    }
}
