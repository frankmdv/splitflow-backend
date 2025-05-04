using Microsoft.EntityFrameworkCore;
using SplitFlow.Domain.Entities.Gestion;
using SplitFlow.Infrastructure.SqlServer.Data;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Repositories.Gestion
{
    public class GastoRepository : IGastoRepository
    {
        private readonly MyDbContext _dbContext;

        public GastoRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddGasto(Gasto gasto)
        {
            await _dbContext.Gastos.AddAsync(gasto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateGasto(Gasto gasto)
        {
            _dbContext.Gastos.Update(gasto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGasto(long id)
        {
            var gasto = await _dbContext.Gastos.FindAsync(id);
            if (gasto != null)
            {
                _dbContext.Gastos.Remove(gasto);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Gasto> GetGastoById(long id)
        {
            return await _dbContext.Gastos
                .Include(p => p.Presupuesto)
                .Include(p => p.MovimientoDebito)
                .Include(p => p.MovimientoCredito)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
