using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion
{
    public class CreditoConfiguration : IEntityTypeConfiguration<Credito>
    {
        public void Configure(EntityTypeBuilder<Credito> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Producto)
                .WithMany(p => p.ListaCredito)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(c => c.IdProducto);

            builder.HasOne(c => c.Estado)
                .WithMany(p => p.ListaEstadoCredito)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(c => c.IdEstado);

        }
    }
}
