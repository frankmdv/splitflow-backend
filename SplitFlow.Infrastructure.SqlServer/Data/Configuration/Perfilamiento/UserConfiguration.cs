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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(150);

            builder.HasOne(u => u.Role)
                .WithMany(u => u.Users)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(u => u.RoleId);
        }
    }
}
