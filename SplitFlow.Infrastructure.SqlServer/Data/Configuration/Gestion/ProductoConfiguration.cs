using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitFlow.Domain.Entities.Gestion;
using SplitFlow.Domain.Entities.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(u => u.Nombre).IsRequired().HasMaxLength(100);

            builder.HasOne(p => p.TipoProducto)
                .WithMany(p => p.ListaTipoProducto)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.IdTipoProducto);

            builder.HasOne(p => p.Cuenta)
                .WithMany(p => p.ListaProducto)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.IdCuenta);
        }
    }
}
