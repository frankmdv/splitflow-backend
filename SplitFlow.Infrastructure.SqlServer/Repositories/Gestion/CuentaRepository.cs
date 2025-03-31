using SplitFlow.Domain.Entities.Gestion;
using SplitFlow.Domain.Entities.Parametrizacion;
using SplitFlow.Infrastructure.SqlServer.Data;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Repositories.Gestion
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly MyDbContext _dbContext;

        public CuentaRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCuenta(Cuenta cuenta)
        {
            await _dbContext.Cuentas.AddAsync(cuenta);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCuenta(Cuenta cuenta)
        {
            _dbContext.Cuentas.Update(cuenta);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCuenta(long id)
        {
            var cuenta = await _dbContext.Cuentas.FindAsync(id);
            if (cuenta != null)
            {
                _dbContext.Cuentas.Remove(cuenta);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}