using Microsoft.EntityFrameworkCore;
using SplitFlow.Domain.Entities.Gestion;
using SplitFlow.Infrastructure.SqlServer.Data;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Repositories.Gestion
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MyDbContext _dbContext;

        public ProductoRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProducto(Producto producto)
        {
            await _dbContext.Productos.AddAsync(producto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCuenta(Producto producto)
        {
            _dbContext.Productos.Update(producto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCuenta(long id)
        {
            var producto = await _dbContext.Productos.FindAsync(id);
            if (producto != null)
            {
                _dbContext.Productos.Remove(producto);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Producto> GetProductoById(long id)
        {
            return await _dbContext.Productos
                .Include(p => p.Cuenta)
                .Include(p => p.TipoProducto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
