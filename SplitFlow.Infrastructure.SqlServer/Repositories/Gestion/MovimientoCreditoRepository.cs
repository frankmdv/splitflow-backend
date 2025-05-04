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
    public class MovimientoCreditoRepository : IMovimientoCreditoRepository
    {
        private readonly MyDbContext _dbContext;

        public MovimientoCreditoRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMovCredito(MovimientoCredito movCredito)
        {
            await _dbContext.MovimientosCredito.AddAsync(movCredito);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMovCredito(MovimientoCredito movCredito)
        {
            _dbContext.MovimientosCredito.Update(movCredito);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMovCredito(long id)
        {
            var movCredito = await _dbContext.MovimientosCredito.FindAsync(id);
            if (movCredito != null)
            {
                _dbContext.MovimientosCredito.Remove(movCredito);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<MovimientoCredito> GetMovCreditoById(long id)
        {
            return await _dbContext.MovimientosCredito
                .Include(mc => mc.Credito)
                .Include(mc => mc.TipoMovimiento)
                .Include(mc => mc.Cuota)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
