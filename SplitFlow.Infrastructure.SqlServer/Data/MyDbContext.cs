using Microsoft.EntityFrameworkCore;
using SplitFlow.Domain.Entities.Gestion;
using SplitFlow.Domain.Entities.Parametrizacion;
using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Infrastructure.SqlServer.Data.Configuration.Gestion;
using SplitFlow.Infrastructure.SqlServer.Data.Configuration.Parametrizacion;
using SplitFlow.Infrastructure.SqlServer.Data.Configuration.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.SqlServer.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        #region Perfilamiento
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<RolModulo> RolModulo { get; set; }
        #endregion

        #region Parametrizacion
        public DbSet<ParametroGeneral> ParGeneral { get; set; }
        public DbSet<ParametroEspecifico> ParEspecifico { get; set; }
        #endregion

        #region Gestion
        public DbSet<Cuenta> Cuenta { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Perfilamiento
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RolModuloConfiguration());
            #endregion

            #region Parametrizacion
            modelBuilder.ApplyConfiguration(new PGeneralConfiguration());
            modelBuilder.ApplyConfiguration(new PEspecificoConfiguration());
            #endregion

            #region Gestion
            modelBuilder.ApplyConfiguration(new CuentaConfiguration());
            modelBuilder.ApplyConfiguration(new ProductoConfiguration());
            #endregion

        }
    }
}
