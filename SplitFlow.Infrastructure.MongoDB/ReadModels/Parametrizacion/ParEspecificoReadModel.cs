using SplitFlow.Domain.Entities.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion
{
    public class ParEspecificoReadModel
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public ParGeneralReadModel ParametroGeneral { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
