using SplitFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento
{
    public class RolModuloReadModel
    {
        public long Id { get; set; }
        public RoleReadModel Role { get; set; }
        public ModuloReadModel Modulo { get; set; }
    }
}
