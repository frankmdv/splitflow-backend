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
    public class PresupuestoConfiguration : IEntityTypeConfiguration<Presupuesto>
    {
        public void Configure(EntityTypeBuilder<Presupuesto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.ListaPresupuestosUsuarios)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.IdUsuario);

            builder.HasOne(p => p.Categoria)
                .WithMany(p => p.ListaCategoriaPresupuesto)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.IdCategoria);
        }
    }
}
