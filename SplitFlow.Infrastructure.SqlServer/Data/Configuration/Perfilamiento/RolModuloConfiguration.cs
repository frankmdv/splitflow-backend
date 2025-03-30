using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplitFlow.Domain.Entities.Perfilamiento;

namespace SplitFlow.Infrastructure.SqlServer.Data.Configuration.Perfilamiento
{
    public class RolModuloConfiguration : IEntityTypeConfiguration<RolModulo>
    {
        public void Configure(EntityTypeBuilder<RolModulo> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Role)
                .WithMany(r => r.RolesModulos)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(r => r.RoleId);

            builder.HasOne(m => m.Modulo)
                .WithMany(m => m.RolesModulos)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(m => m.ModuloId);
        }
    }
}
