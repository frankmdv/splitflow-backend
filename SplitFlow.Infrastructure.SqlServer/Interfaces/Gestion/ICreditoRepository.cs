using SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion
{
    public interface ICreditoRepository
    {
        Task AddCredito(Credito credito);
        Task UpdateGasto(Credito credito);
        Task DeleteGasto(long id);
        Task<Credito> GetCreditoById(long id);
    }
}
