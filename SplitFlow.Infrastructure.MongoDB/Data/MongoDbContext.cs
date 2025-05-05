using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;


namespace SplitFlow.Infrastructure.MongoDB.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("MyAppReadDb");
        }

        //Agregar modelos de lectura aqui
        #region Perfilamiento
        public IMongoCollection<UserReadModel> Users => _database.GetCollection<UserReadModel>("Users");
        public IMongoCollection<RoleReadModel> Roles => _database.GetCollection<RoleReadModel>("Roles");
        public IMongoCollection<ModuloReadModel> Modulos => _database.GetCollection<ModuloReadModel>("Modules");
        public IMongoCollection<RolModuloReadModel> RolModulo => _database.GetCollection<RolModuloReadModel>("RolModulo");
        #endregion
        #region Parametrizacion
        public IMongoCollection<ParGeneralReadModel> ParametroGeneral => _database.GetCollection<ParGeneralReadModel>("ParametroGeneral");
        public IMongoCollection<ParEspecificoReadModel> ParametroEspecifico => _database.GetCollection<ParEspecificoReadModel>("ParametroEspecifico");
        #endregion
        #region Gestion
        public IMongoCollection<CuentaReadModel> Cuentas => _database.GetCollection<CuentaReadModel>("Cuentas");
        public IMongoCollection<ProductoReadModel> Productos => _database.GetCollection<ProductoReadModel>("Productos");
        public IMongoCollection<MovimientoDebitoReadModel> MovimientoDebito => _database.GetCollection<MovimientoDebitoReadModel>("MovimientoDebito");
        public IMongoCollection<PresupuestoReadModel> Presupuesto => _database.GetCollection<PresupuestoReadModel>("Presupuesto");
        public IMongoCollection<CreditoReadModel> Credito => _database.GetCollection<CreditoReadModel>("Credito");
        public IMongoCollection<CuotaReadModel> Cuotas => _database.GetCollection<CuotaReadModel>("Cuotas");
        public IMongoCollection<MovimientoCreditoReadModel> MovimientoCredito => _database.GetCollection<MovimientoCreditoReadModel>("MovimientoCredito");
        public IMongoCollection<GastoReadModel> Gastos => _database.GetCollection<GastoReadModel>("Gastos");
        #endregion
    }
}
