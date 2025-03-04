using MediatR;
using SplitFlow.Application.Commands.Perfilamiento;
using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Domain.Events.Perfilamiento;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Perfilamiento;

namespace SplitFlow.Application.Handlers.Perfilamiento.Roles
{
    public class RoleCommandHandler : IRequestHandler<CreateRoleCommand, long>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMediator _mediator;

        public RoleCommandHandler(IRoleRepository roleRepository, IMediator mediator)
        {
            _roleRepository = roleRepository;
            _mediator = mediator;
        }

        public async Task<long> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role
            {
                Name = request.Name,
                Description = request.Description
            };

            await _roleRepository.AddAsync(role);

            //Publicar evento para que MongoDB lo registre
            await _mediator.Publish(new RoleCreatedEvent
            {
                RoleId = role.Id,
                Name = role.Name,
                Description = role.Description
            });

            return role.Id;
        }
    }
}

