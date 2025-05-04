using Microsoft.EntityFrameworkCore;
using SplitFlow.Domain.Entities.Gestion;
using SplitFlow.Infrastructure.SqlServer.Data;
using SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Repositories.Gestion
{
    public class PresupuestoRepository : IPresupuestoRepository
    {
        private readonly MyDbContext _dbContext;

        public PresupuestoRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPresupuesto(Presupuesto presupuesto)
        {
            await _dbContext.Presupuestos.AddAsync(presupuesto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePresupuesto(Presupuesto presupuesto)
        {
            _dbContext.Presupuestos.Update(presupuesto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePresupuesto(long id)
        {
            var presupuesto = await _dbContext.Presupuestos.FindAsync(id);
            if (presupuesto != null)
            {
                _dbContext.Presupuestos.Remove(presupuesto);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Presupuesto> GetPresupuestoById(long id)
        {
            return await _dbContext.Presupuestos
                .Include(p => p.Usuario)
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
