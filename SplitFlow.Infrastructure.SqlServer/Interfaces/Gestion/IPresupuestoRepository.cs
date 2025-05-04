using SplitFlow.Domain.Entities.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion
{
    public interface IPresupuestoRepository
    {
        Task AddPresupuesto(Presupuesto presupuesto);
        Task UpdatePresupuesto(Presupuesto presupuesto);
        Task DeletePresupuesto(long id);
        Task<Presupuesto> GetPresupuestoById(long id);
    }
}
