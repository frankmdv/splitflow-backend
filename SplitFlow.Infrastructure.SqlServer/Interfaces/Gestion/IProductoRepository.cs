using SplitFlow.Domain.Entities.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion
{
    public interface IProductoRepository
    {
        Task AddProducto(Producto producto);
        Task UpdateCuenta(Producto producto);
        Task DeleteCuenta(long id);
    }
}
