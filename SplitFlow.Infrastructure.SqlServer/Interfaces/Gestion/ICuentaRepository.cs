using SplitFlow.Domain.Entities.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion
{
    public interface ICuentaRepository
    {
        Task AddCuenta(Cuenta cuenta);
        Task UpdateCuenta(Cuenta cuenta);
        Task DeleteCuenta(long id);
    }
}
