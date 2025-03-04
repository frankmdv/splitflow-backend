using SplitFlow.Domain.Entities.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Interfaces.Perfilamiento
{
    public interface IRolModuloRepository
    {
        Task AddAsync(RolModulo rolModulo);
    }
}
