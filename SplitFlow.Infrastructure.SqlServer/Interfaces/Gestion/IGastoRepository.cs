using SplitFlow.Domain.Entities.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion
{
    public interface IGastoRepository
    {
        Task AddGasto(Gasto gasto);
        Task UpdateGasto(Gasto gasto);
        Task DeleteGasto(long id);
        Task<Gasto> GetGastoById(long id);
    }
}
