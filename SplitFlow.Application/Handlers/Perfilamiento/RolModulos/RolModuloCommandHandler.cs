using MediatR;
using SplitFlow.Application.Commands.Perfilamiento;
using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Domain.Events.Perfilamiento;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Perfilamiento;
using SplitFlow.Infrastructure.SqlServer.Repositories.Perfilamiento;

namespace SplitFlow.Application.Handlers.Perfilamiento.RolModulos
{
    public class RolModuloCommandHandler : IRequestHandler<CreateRolModuloCommand, long>
    {
        private readonly IRolModuloRepository _roleModuloRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IModuloRepository _moduloRepository;
        private readonly IMediator _mediator;

        public RolModuloCommandHandler
        (IRolModuloRepository rolModuloRepository,
        IMediator mediator,
        IRoleRepository roleRepository,
        IModuloRepository moduloRepository)
        {
            _roleModuloRepository = rolModuloRepository;
            _roleRepository = roleRepository;
            _moduloRepository = moduloRepository;
            _mediator = mediator;
        }

        public async Task<long> Handle(CreateRolModuloCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(request.RoleId);
            if (role == null)
                throw new Exception("El rol especificado no existe.");

            var modulo = await _moduloRepository.GetByIdAsync(request.ModuloId);
            if (modulo == null)
                throw new Exception("El modulo especificado no existe.");


            var rolModulo = new RolModulo
            {
                RoleId = request.RoleId,
                ModuloId = request.ModuloId
            };

            await _roleModuloRepository.AddAsync(rolModulo);

            //Publicar evento para que MongoDB lo registre
            await _mediator.Publish(new RolModuloCreatedEvent
            {
                Id = rolModulo.Id,
                Role = new RoleCreatedEvent
                {
                    RoleId = role.Id,
                    Name = role.Name,
                    Description = role.Description,

                },
                Modulo = new ModuloCreatedEvent
                {
                    Id = modulo.Id,
                    Name = modulo.Name,
                    Level = modulo.Level,
                    Type = modulo.Type,
                    CreateAt = modulo.CreateAt
                }

            });

            return rolModulo.Id;
        }
    }
}

