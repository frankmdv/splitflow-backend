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
    public class MovimientoDebitoConfiguration : IEntityTypeConfiguration<MovimientoDebito>
    {
        public void Configure(EntityTypeBuilder<MovimientoDebito> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Producto)
                .WithMany(p => p.ListaMovimientoDebito)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.IdProducto);

            builder.HasOne(p => p.TipoMovimiento)
                .WithMany(p => p.ListaTipoMovimientoDebito)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.IdTipoMovimiento);
        }
    }
}
