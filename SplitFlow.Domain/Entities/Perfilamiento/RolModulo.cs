using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Entities.Perfilamiento
{
    public class RolModulo
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
        public long ModuloId { get; set; }
        public Modulo Modulo { get; set; }
    }
}
