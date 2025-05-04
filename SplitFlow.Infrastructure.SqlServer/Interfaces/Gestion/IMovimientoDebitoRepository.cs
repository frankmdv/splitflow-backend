using SplitFlow.Domain.Entities.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion
{
    public interface IMovimientoDebitoRepository
    {
        Task AddMovimientoDebito(MovimientoDebito movimiento);
        Task UpdateMovimientoDebito(MovimientoDebito movimiento);
        Task DeleteMovimientoDebito(long id);
        Task<MovimientoDebito> GetMovDebitoById(long id);
    }
}
