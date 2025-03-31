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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Parametrizacion;
using SplitFlow.Infrastructure.SqlServer.Repositories.Parametrizacion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion;
using SplitFlow.Infrastructure.SqlServer.Repositories.Gestion;

var builder = WebApplication.CreateBuilder(args);


// 🔹 Cargar configuración desde appsettings.json
var configuration = builder.Configuration;

// 🔹 Agregar servicios a la aplicación
var services = builder.Services;

// ✅ Configurar MediatR (CQRS)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
#region Perfilamiento
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
#endregion
#region Parametrizacion
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

// ✅ Inyección de dependencias para Repositorios
#region Inyeccion de dependencias

#region Perfilamiento
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IRoleRepository, RoleRepository>();
services.AddScoped<IModuloRepository, ModuloRepository>();
services.AddScoped<IRolModuloRepository, RolModuloRepository>();
#endregion
#region Parametrizacion
services.AddScoped<IParGenYEspeRepository, ParGenYEspeRepository>();
#endregion
#region Gestion
services.AddScoped<ICuentaRepository, CuentaRepository>();
services.AddScoped<IProductoRepository, ProductoRepository>();
services.AddScoped<IMovimientoDebitoRepository, MovimientoDebitoRepository>();
#endregion

#endregion

// ✅ Configurar JWT Authentication
var jwtSettings = configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["Secret"] ?? "TuClaveSecretaMuyLargaParaSeguridad";
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});



// ✅ Agregar Controladores y swagger
services.AddControllers();
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

