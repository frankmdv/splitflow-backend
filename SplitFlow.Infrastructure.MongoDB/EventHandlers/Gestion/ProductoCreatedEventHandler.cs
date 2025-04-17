using MediatR;
using MongoDB.Driver;
using SplitFlow.Domain.Events.Gestion;
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
    public class ProductoCreatedEventHandler : INotificationHandler<ProductoCreatedEvent>
    {
        private readonly IMongoCollection<ProductoReadModel> _productos;

        public ProductoCreatedEventHandler(IMongoDatabase database)
        {
            _productos = database.GetCollection<ProductoReadModel>("Productos");
        }

        public async Task Handle(ProductoCreatedEvent notification, CancellationToken cancellationToken)
        {
            var producto = new ProductoReadModel
            {
                Id = notification.ProductoId,
                Cuenta = new CuentaReadModel
                {
                    Id = notification.Cuenta.CuentaId,
                    Usuario = new UserReadModel
                    {
                        Id = notification.Cuenta.Usuario.UserId,
                        Username = notification.Cuenta.Usuario.Username
                    },
                    TipoCuenta = new ParEspecificoReadModel
                    {
                        Id = notification.Cuenta.TipoCuenta.ParEspeId,
                        Nombre = notification.Cuenta.TipoCuenta.Nombre
                    },
                    Banco = new ParEspecificoReadModel
                    {
                        Id = notification.Cuenta.Banco.ParEspeId,
                        Nombre = notification.Cuenta.Banco.Nombre
                    },
                    NombreCuenta = notification.Cuenta.NombreCuenta
                },
                TipoProducto = new ParEspecificoReadModel
                {
                    Id = notification.TipoProducto.ParEspeId,
                    Nombre = notification.TipoProducto.Nombre
                },
                Nombre = notification.Nombre,
                NumeroProducto = notification.NumeroProducto,
                FechaVencimiento = notification.FechaVencimiento,
                IsActive = notification.IsActive,
                Saldo = notification.Saldo,
                LimiteCredito = notification.LimiteCredito,
                SaldoDisponible = notification.SaldoDisponible,
                TasaInteresanual = notification.TasaInteresanual,
                FechaCorte = notification.FechaCorte,
                FechaLimitePago = notification.FechaLimitePago,
                CreateAt = notification.CreateAt,
                LastUpdate = notification.LastUpdate
            };

            await _productos.InsertOneAsync(producto, cancellationToken: cancellationToken);
        }
    }
}
