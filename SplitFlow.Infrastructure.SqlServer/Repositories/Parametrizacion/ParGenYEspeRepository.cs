using SplitFlow.Domain.Entities.Parametrizacion;
using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Infrastructure.SqlServer.Data;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Repositories.Parametrizacion
{
    public class ParGenYEspeRepository : IParGenYEspeRepository
    {
        private readonly MyDbContext _dbContext;

        public ParGenYEspeRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddParGeneral(ParametroGeneral pGeneral)
        {
            await _dbContext.ParGeneral.AddAsync(pGeneral);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddParEspecifico(ParametroEspecifico pEspecifico)
        {
            await _dbContext.ParEspecifico.AddAsync(pEspecifico);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateParGeneral(ParametroGeneral pGeneral)
        {
            _dbContext.ParGeneral.Update(pGeneral);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateParEspecifico(ParametroEspecifico pEspecifico)
        {
            _dbContext.ParEspecifico.Update(pEspecifico);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ParametroEspecifico> GetParEspecificoById(long id)
        {
            return await _dbContext.ParEspecifico.FindAsync(id);
        }
    }
}
