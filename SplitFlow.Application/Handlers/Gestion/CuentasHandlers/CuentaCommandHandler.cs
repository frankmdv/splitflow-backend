using MediatR;
using SplitFlow.Application.Commands.Gestion.CuentaCommands;
using SplitFlow.Domain.Entities.Gestion;
using SplitFlow.Domain.Events.Gestion;
using SplitFlow.Domain.Events.Parametrizacion;
using SplitFlow.Domain.Events.Perfilamiento;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Parametrizacion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Gestion.CuentasHandlers
{
    public class CuentaCommandHandler : IRequestHandler<CreateCuentaCommand, long>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IUserRepository _userRepository;
        private readonly IParGenYEspeRepository _parGenYEspeRepository;
        private readonly IMediator _mediator;

        public CuentaCommandHandler(
            ICuentaRepository cuentaRepository,
            IParGenYEspeRepository parGenYEspeRepository,
            IUserRepository userRepository,
            IMediator mediator)
        {
            _cuentaRepository = cuentaRepository;
            _parGenYEspeRepository = parGenYEspeRepository;
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<long> Handle(CreateCuentaCommand request, CancellationToken cancellationToken)
        {
            var tipoCuenta = await _parGenYEspeRepository.GetParEspecificoById(request.TipoCuentaId);
            var banco = await _parGenYEspeRepository.GetParEspecificoById(request.BancoId);
            var moneda = await _parGenYEspeRepository.GetParEspecificoById(request.MonedaId);
            var usuario = await _userRepository.GetUserById(request.UsuarioId);

            var cuenta = new Cuenta
            {
                IdUsuario = request.UsuarioId,
                IdTipoCuenta = request.TipoCuentaId,
                NombreCuenta = request.NombreCuenta,
                IdBanco = request.BancoId,
                IdMoneda = request.MonedaId,
                Estado = request.Estado,
            };

            await _cuentaRepository.AddCuenta(cuenta);

            await _mediator.Publish(new CuentaCreatedEvent
            {
                CuentaId = cuenta.Id,
                Usuario = new UserCreatedEvent
                {
                    UserId = request.UsuarioId,
                    Username = usuario.Username,
                    Email = usuario.Email,
                    IsActive = usuario.IsActive
                },
                TipoCuenta = new ParEspecificoCreatedEvent
                {
                    ParEspeId = tipoCuenta.Id,
                    Nombre = tipoCuenta.Nombre,
                    Estado = tipoCuenta.Estado
                },
                Banco = new ParEspecificoCreatedEvent
                {
                    ParEspeId = banco.Id,
                    Nombre = banco.Nombre,
                    Estado = banco.Estado
                },
                NombreCuenta = cuenta.NombreCuenta,
                Moneda = new ParEspecificoCreatedEvent
                {
                    ParEspeId = moneda.Id,
                    Nombre = moneda.Nombre,
                    Estado = moneda.Estado
                },
                Estado = cuenta.Estado
            });

            return cuenta.Id;
        }
    }
}
