using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SplitFlow.Infrastructure.MongoDB.ReadModels;


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
        public IMongoCollection<UserReadModel> Users => _database.GetCollection<UserReadModel>("Users");
    }
}
