using SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion
{
    public interface IMovimientoCreditoRepository
    {
        Task AddMovCredito(MovimientoCredito movCredito);
        Task UpdateMovCredito(MovimientoCredito movCredito);
        Task DeleteMovCredito(long id);
        Task<MovimientoCredito> GetMovCreditoById(long id);
    }
}
