using SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion;
using SplitFlow.Infrastructure.SqlServer.Data;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SplitFlow.Infrastructure.SqlServer.Repositories.Gestion
{
    public class CuotaRepository : ICuotaRepository
    {
        private readonly MyDbContext _dbContext;

        public CuotaRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCuota(Cuota cuota)
        {
            await _dbContext.Cuotas.AddAsync(cuota);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCuota(Cuota cuota)
        {
            _dbContext.Cuotas.Update(cuota);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCuota(long id)
        {
            var cuota = await _dbContext.Cuotas.FindAsync(id);
            if (cuota != null)
            {
                _dbContext.Cuotas.Remove(cuota);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Cuota> GetCuotaById(long id)
        {
            return await _dbContext.Cuotas
                .Include(c => c.Credito)
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
