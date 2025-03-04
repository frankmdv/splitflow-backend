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
    public class ModuloRepository : IModuloRepository
    {
        private readonly MyDbContext _dbContext;

        public ModuloRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Modulo modulo)
        {
            await _dbContext.Modulos.AddAsync(modulo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Modulo> GetByIdAsync(long id)
        {
            return await _dbContext.Modulos.FindAsync(id);
        }
    }
}
