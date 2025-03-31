using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion
{
    public class CuentaReadModel
    {
        public long Id { get; set; }
        public UserReadModel Usuario { get; set; }
        public ParEspecificoReadModel TipoCuenta { get; set; }
        public ParEspecificoReadModel Banco { get; set; }
        public string NombreCuenta { get; set; }
        public ParEspecificoReadModel Moneda { get; set; }
        public bool Estado { get; set; }
    }
}
