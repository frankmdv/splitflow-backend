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
    public class CuentaConfiguration : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Usuario)
                .WithMany(p => p.ListaUsuarioCuenta)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.IdUsuario);

            builder.HasOne(p => p.TipoCuenta)
                .WithMany(p => p.ListaTipoCuentaCuenta)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.IdTipoCuenta);

            builder.HasOne(p => p.Banco)
                .WithMany(p => p.ListaBancoCuenta)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.IdBanco);

            builder.HasOne(p => p.Moneda)
                .WithMany(p => p.ListaMonedaCuenta)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.IdMoneda);
        }
    }
}
