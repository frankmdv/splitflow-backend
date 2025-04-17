using MediatR;
using MongoDB.Driver;
using SplitFlow.Application.Queries.Gestion.CuentasQuerys;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Gestion.CuentasHandlers
{
    public class CuentaQueryHandler :
    IRequestHandler<GetAllCuentasQuery, List<CuentaReadModel>>,
    IRequestHandler<GetCuentasByIdUsuarioQuery, List<CuentaReadModel>>
    {
        private readonly IMongoCollection<CuentaReadModel> _cuentas;

        public CuentaQueryHandler(IMongoDatabase database)
        {
            _cuentas = database.GetCollection<CuentaReadModel>("Cuentas");
        }
        public async Task<List<CuentaReadModel>> Handle(GetAllCuentasQuery request, CancellationToken cancellationToken)
        {
            return await _cuentas.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task<List<CuentaReadModel>> Handle(GetCuentasByIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _cuentas.Find(c => c.Usuario.Id == request.IdUsuario).ToListAsync(cancellationToken);
        }
    }
}
