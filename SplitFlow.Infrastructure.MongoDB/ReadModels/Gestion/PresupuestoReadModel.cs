using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion
{
    public class PresupuestoReadModel
    {
        public long Id { get; set; }
        public UserReadModel Usuario { get; set; }
        public ParEspecificoReadModel Categoria { get; set; }
        public string MontoAsignado { get; set; }
        public bool Activo { get; set; }
    }
}
