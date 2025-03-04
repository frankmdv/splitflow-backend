using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Infrastructure.SqlServer.Data;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Repositories.Perfilamiento
{
    public class RolModuloRepository : IRolModuloRepository
    {
        private readonly MyDbContext _dbContext;

        public RolModuloRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(RolModulo rolModulo)
        {
            await _dbContext.RolModulo.AddAsync(rolModulo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
