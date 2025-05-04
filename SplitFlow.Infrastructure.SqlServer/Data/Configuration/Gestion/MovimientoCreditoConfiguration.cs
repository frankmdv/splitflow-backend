using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion
{
    public class MovimientoCreditoConfiguration : IEntityTypeConfiguration<MovimientoCredito>
    {
        public void Configure(EntityTypeBuilder<MovimientoCredito> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Credito)
                .WithMany(c => c.ListaMovimientosCredito)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(m => m.IdCredito);

            builder.HasOne(m => m.TipoMovimiento)
                .WithMany(p => p.ListaTipoMovimientoCredito)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(m => m.IdTipoMovimiento);

            builder.HasOne(m => m.Cuota)
                .WithMany(c => c.ListaMovimientosCredito)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(m => m.IdCuota);
        }
    }
}
