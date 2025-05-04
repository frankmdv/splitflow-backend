using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion
{
    public class CuotaConfiguration : IEntityTypeConfiguration<Cuota>
    {
        public void Configure(EntityTypeBuilder<Cuota> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Credito)
                .WithMany(c => c.ListaCuotasCredito)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(c => c.IdCredito);

            builder.HasOne(c => c.Estado)
                .WithMany(p => p.ListaEstadosCuotas)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(c => c.IdEstado);
        }
    }
}
