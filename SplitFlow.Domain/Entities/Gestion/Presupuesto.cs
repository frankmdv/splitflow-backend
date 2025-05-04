using SplitFlow.Domain.Entities.Parametrizacion;
using SplitFlow.Domain.Entities.Perfilamiento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Entities.Gestion
{
    [Table("Presupuesto", Schema = "GES")]
    public class Presupuesto
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public virtual User Usuario { get; set; }
        public long IdCategoria { get; set; }
        public virtual ParametroEspecifico Categoria { get; set; }
        public string MontoAsignado { get; set; }
        public bool Activo { get; set; } = true;

        public List<Gasto> ListaGasto { get; set; } = new List<Gasto>();
    }
}
