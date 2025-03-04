using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SplitFlow.Application.Commands;
using SplitFlow.Application.Handlers.Perfilamiento.Modulos;
using SplitFlow.Application.Handlers.Perfilamiento.Roles;
using SplitFlow.Application.Handlers.Perfilamiento.RolModulos;
using SplitFlow.Application.Handlers.Perfilamiento.Users;
using SplitFlow.Infrastructure.MongoDB.Data;
using SplitFlow.Infrastructure.MongoDB.EventHandlers.Perfilamiento;
using SplitFlow.Infrastructure.SqlServer.Data;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Perfilamiento;
using SplitFlow.Infrastructure.SqlServer.Repositories.Perfilamiento;

var builder = WebApplication.CreateBuilder(args);


// 🔹 Cargar configuración desde appsettings.json
var configuration = builder.Configuration;

// 🔹 Agregar servicios a la aplicación
var services = builder.Services;

// ✅ Configurar MediatR (CQRS)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    #region Usuarios
    typeof(UserCommandHandler).Assembly,
    typeof(UserQueryHandler).Assembly,
    typeof(UserCreatedEventHandler).Assembly,
    #endregion
    #region Roles
    typeof(RoleCommandHandler).Assembly,
    typeof(RoleQueryHandler).Assembly,
    typeof(RoleCreatedEventHandler).Assembly,
    #endregion
    #region Modulos
    typeof(ModuloCommandHandler).Assembly,
    typeof(ModuloQueryHandler).Assembly,
    typeof(ModuloCreatedEventHandler).Assembly,
    #endregion
    #region RolModulo
    typeof(RolModuloCommandHandler).Assembly,
    typeof(RolModuloQueryHandler).Assembly,
    typeof(RolModuloCreatedEventHandler).Assembly
    #endregion
));

#region Confuguracion SQL
// ✅ Configurar SQL Server con EF Core
services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
#endregion

#region Configuracion NOSQL
// ✅ Configurar MongoDB
var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDb"));
var mongoDatabase = mongoClient.GetDatabase("Db_ReadSlipFlow");
services.AddSingleton<IMongoClient>(mongoClient);
services.AddScoped<IMongoDatabase>(sp => mongoDatabase);
services.AddSingleton<MongoDbContext>();
#endregion

#region Inyeccion de dependencias
// ✅ Inyección de dependencias para Repositorios
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IRoleRepository, RoleRepository>();
services.AddScoped<IModuloRepository, ModuloRepository>();
services.AddScoped<IRolModuloRepository, RolModuloRepository>();
#endregion

// ✅ Agregar Controladores
services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Configurar el Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

