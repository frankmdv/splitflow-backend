using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitFlow.Domain.Entities.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion
{
    public class GastoConfiguration : IEntityTypeConfiguration<Gasto>
    {
        public void Configure(EntityTypeBuilder<Gasto> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasOne(g => g.Presupuesto)
                .WithMany(p =>p.ListaGasto)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(g => g.IdPresupuesto);

            builder.HasOne(g => g.MovimientoDebito)
                .WithMany(m => m.ListaGastoDebito)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(g => g.IdMovimientoDebito);

            builder.HasOne(g => g.MovimientoCredito)
                .WithMany(m => m.ListaGastoCredito)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(g => g.IdMovimientoCredito);
        }
    }
}
