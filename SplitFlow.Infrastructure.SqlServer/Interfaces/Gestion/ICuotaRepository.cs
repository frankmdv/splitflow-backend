using SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion
{
    public interface ICuotaRepository
    {
        Task AddCuota(Cuota cuota);
        Task UpdateCuota(Cuota cuota);
        Task DeleteCuota(long id);
        Task<Cuota> GetCuotaById(long id);
    }
}
