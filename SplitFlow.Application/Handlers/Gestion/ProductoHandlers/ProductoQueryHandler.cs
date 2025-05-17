using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Gestion.ProductoQueries;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;

namespace SplitFlow.Application.Handlers.Gestion.ProductoHandlers
{
    public class ProductoQueryHandler :
    IRequestHandler<GetAllProductosQuery, List<ProductoReadModel>>,
    IRequestHandler<GetProductoByIdCuenta, List<ProductoReadModel>>,
    IRequestHandler<GetProductoById, ProductoReadModel>
    {
        private readonly IMongoCollection<ProductoReadModel> _products;
            
        public ProductoQueryHandler(IMongoDatabase database)
        {
            _products = database.GetCollection<ProductoReadModel>("Productos");
        }

        public async Task<List<ProductoReadModel>> Handle(GetAllProductosQuery request, CancellationToken cancellationToken)
        {
            return await _products.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<List<ProductoReadModel>> Handle(GetProductoByIdCuenta request, CancellationToken cancellationToken)
        {
            return await _products.Find(p => p.Cuenta.Id == request.IdCuenta).ToListAsync(cancellationToken);
        }

        public async Task<ProductoReadModel> Handle(GetProductoById request, CancellationToken cancellationToken)
        {
            return await _products.Find(p => p.Id == request.IdProducto).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
