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
    public class CreditoRepository : ICreditoRepository
    {
        private readonly MyDbContext _dbContext;

        public CreditoRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCredito(Credito credito)
        {
            await _dbContext.Credito.AddAsync(credito);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateGasto(Credito credito)
        {
            _dbContext.Credito.Update(credito);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGasto(long id)
        {
            var credito = await _dbContext.Credito.FindAsync(id);
            if (credito != null)
            {
                _dbContext.Credito.Remove(credito);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Credito> GetCreditoById(long id)
        {
            return await _dbContext.Credito
                .Include(c => c.Producto)
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
