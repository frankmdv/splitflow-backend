using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SplitFlow.Application.Commands;
using SplitFlow.Application.Handlers.Roles;
using SplitFlow.Application.Handlers.Users;
using SplitFlow.Infrastructure.MongoDB.Data;
using SplitFlow.Infrastructure.MongoDB.EventHandlers;
using SplitFlow.Infrastructure.SqlServer.Data;
using SplitFlow.Infrastructure.SqlServer.Interfaces;
using SplitFlow.Infrastructure.SqlServer.Repositories;

var builder = WebApplication.CreateBuilder(args);


// 🔹 Cargar configuración desde appsettings.json
var configuration = builder.Configuration;

// 🔹 Agregar servicios a la aplicación
var services = builder.Services;

// ✅ Configurar MediatR (CQRS)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(UserCommandHandler).Assembly,
    typeof(UserQueryHandler).Assembly,
    typeof(UserCreatedEventHandler).Assembly,
    typeof(RoleCommandHandler).Assembly,
    typeof(RoleQueryHandler).Assembly,
    typeof(RoleCreatedEventHandler).Assembly
));

// ✅ Configurar SQL Server con EF Core
services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

// ✅ Configurar MongoDB
var mongoClient = new MongoClient(configuration.GetConnectionString("MongoDb"));
var mongoDatabase = mongoClient.GetDatabase("Db_ReadSlipFlow");
services.AddSingleton<IMongoClient>(mongoClient);
services.AddScoped<IMongoDatabase>(sp => mongoDatabase);
services.AddSingleton<MongoDbContext>();

var collections = mongoDatabase.ListCollectionNames().ToList();
if (!collections.Contains("Users"))
    mongoDatabase.CreateCollection("Users");


// ✅ Inyección de dependencias para Repositorios
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IRoleRepository, RoleRepository>();

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

