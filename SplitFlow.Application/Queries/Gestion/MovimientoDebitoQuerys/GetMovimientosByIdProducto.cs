using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;

namespace SplitFlow.Application.Queries.Gestion.MovimientoDebitoQuerys
{
    public class GetMovimientosByIdProducto : IRequest<List<MovimientoDebitoReadModel>>
    {
        public long IdProducto { get; set; }

        public GetMovimientosByIdProducto(long idProducto)
        {
            IdProducto = idProducto;
        }
    }
}
