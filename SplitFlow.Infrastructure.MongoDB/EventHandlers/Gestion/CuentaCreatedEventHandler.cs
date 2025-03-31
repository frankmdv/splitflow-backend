using MediatR;
using MongoDB.Driver;
using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Domain.Events.Gestion;
using SplitFlow.Domain.Events.Perfilamiento;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Gestion;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Parametrizacion;
using SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.EventHandlers.Gestion
{
    public class CuentaCreatedEventHandler : INotificationHandler<CuentaCreatedEvent>
    {
        private readonly IMongoCollection<CuentaReadModel> _cuentas;

        public CuentaCreatedEventHandler(IMongoDatabase database)
        {
            _cuentas = database.GetCollection<CuentaReadModel>("Cuentas");
        }

        public async Task Handle(CuentaCreatedEvent notification, CancellationToken cancellationToken)
        {
            var cuenta = new CuentaReadModel
            {
                Id = notification.CuentaId,
                Usuario = new UserReadModel
                {
                    Id = notification.Usuario.UserId,
                    Username = notification.Usuario.Username,
                    Email = notification.Usuario.Email,
                    Role = new RoleReadModel
                    {
                        Id = notification.Usuario.Role.RoleId,
                        Name = notification.Usuario.Role.Name,
                        Description = notification.Usuario.Role.Description
                    },
                    IsActive = notification.Usuario.IsActive,
                    CreatedAt = notification.Usuario.CreatedAt
                },
                TipoCuenta = new ParEspecificoReadModel
                {
                    Id = notification.TipoCuenta.ParEspeId,
                    Nombre = notification.TipoCuenta.Nombre,
                    Estado = notification.TipoCuenta.Estado,
                },
                Banco = new ParEspecificoReadModel
                {
                    Id = notification.Banco.ParEspeId,
                    Nombre = notification.Banco.Nombre,
                    Estado = notification.Banco.Estado,
                },
                NombreCuenta = notification.NombreCuenta,
                Moneda = new ParEspecificoReadModel
                {
                    Id = notification.Moneda.ParEspeId,
                    Nombre = notification.Moneda.Nombre,
                    Estado = notification.Moneda.Estado,
                },
                Estado = notification.Estado

            };

            await _cuentas.InsertOneAsync(cuenta, cancellationToken: cancellationToken);
        }
    }
}
