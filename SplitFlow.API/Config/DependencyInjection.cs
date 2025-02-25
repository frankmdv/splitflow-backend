using MediatR;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SplitFlow.Application.Commands;
using SplitFlow.Infrastructure.SqlServer.Data;

namespace SplitFlow.API.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(CreateUserCommand).Assembly);

            // SQL Server
            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            // MongoDB
            services.AddSingleton<IMongoClient>(new MongoClient(configuration.GetConnectionString("MongoDb")));
            services.AddScoped<IMongoDatabase>(sp =>
                sp.GetRequiredService<IMongoClient>().GetDatabase("MyAppReadDb"));

            return services;
        }
    }
}
