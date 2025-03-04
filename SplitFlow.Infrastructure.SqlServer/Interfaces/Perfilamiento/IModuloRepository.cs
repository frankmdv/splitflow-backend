using SplitFlow.Domain.Entities.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Interfaces.Perfilamiento
{
    public interface IModuloRepository
    {
        Task AddAsync(Modulo modulo);
        Task<Modulo> GetByIdAsync(long id);
    }
}
