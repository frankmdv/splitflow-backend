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
    public class MovimientoDebitoRepository : IMovimientoDebitoRepository
    {
        private readonly MyDbContext _dbContext;

        public MovimientoDebitoRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddMovimientoDebito(MovimientoDebito movimiento)
        {
            await _dbContext.MovimientosDebito.AddAsync(movimiento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMovimientoDebito(MovimientoDebito movimiento)
        {
            _dbContext.MovimientosDebito.Update(movimiento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMovimientoDebito(long id)
        {
            var movimiento = await _dbContext.MovimientosDebito.FindAsync(id);
            if (movimiento != null)
            {
                _dbContext.MovimientosDebito.Remove(movimiento);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<MovimientoDebito> GetMovDebitoById(long id)
        {
            return await _dbContext.MovimientosDebito
                .Include(md => md.Producto)
                .Include(md => md.TipoMovimiento)
                .FirstOrDefaultAsync(md => md.Id == id);
        }
    }
}
