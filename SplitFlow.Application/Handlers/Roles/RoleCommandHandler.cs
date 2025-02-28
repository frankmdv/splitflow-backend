using MediatR;
using SplitFlow.Application.Commands;
using SplitFlow.Domain.Entities;
using SplitFlow.Domain.Events;
using SplitFlow.Infrastructure.SqlServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Roles
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

            // 🔥 Publicar evento para que MongoDB lo registre
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

