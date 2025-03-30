using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitFlow.Domain.Entities.Parametrizacion;
using SplitFlow.Domain.Entities.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Data.Configuration.Parametrizacion
{
    public class PEspecificoConfiguration : IEntityTypeConfiguration<ParametroEspecifico>
    {
        public void Configure(EntityTypeBuilder<ParametroEspecifico> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(u => u.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Estado).IsRequired().HasMaxLength(150);

            builder.HasOne(p => p.ParametroGeneral)
                .WithMany(p => p.ParametroEspecificos)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.IdParGeneral);
        }
    }
}
