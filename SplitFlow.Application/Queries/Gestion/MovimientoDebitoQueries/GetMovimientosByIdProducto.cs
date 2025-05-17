using MediatR;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;

namespace SplitFlow.Application.Queries.Gestion.MovimientoDebitoQueries
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
