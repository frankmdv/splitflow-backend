using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Entities.Parametrizacion
{
    [Table("ParametroGeneral", Schema = "PAR")]
    public class ParametroGeneral
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime CreateAt { get; set; }
        public List<ParametroEspecifico> ParametroEspecificos { get; set; } = new List<ParametroEspecifico>();
    }
}
