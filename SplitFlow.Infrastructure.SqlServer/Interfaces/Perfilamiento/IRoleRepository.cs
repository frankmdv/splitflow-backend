using SplitFlow.Domain.Entities.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Interfaces.Perfilamiento
{
    public interface IRoleRepository
    {
        Task AddAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(long id);
        Task<Role> GetByIdAsync(long id);
    }
}
