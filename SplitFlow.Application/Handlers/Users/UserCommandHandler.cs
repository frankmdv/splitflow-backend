using MediatR;
using SplitFlow.Application.Commands;
using SplitFlow.Domain.Entities;
using SplitFlow.Domain.Events;
using SplitFlow.Infrastructure.SqlServer.Data;
using SplitFlow.Infrastructure.SqlServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using SplitFlow.Infrastructure.SqlServer.Repositories;
using SplitFlow.Infrastructure.MongoDB.ReadModels;

namespace SplitFlow.Application.Handlers.Users
{
    public class UserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMediator _mediator;

        public UserCommandHandler(IUserRepository userRepository, IMediator mediator, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _roleRepository = roleRepository;
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //Encriptar la contraseña antes de guardarla
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var role = await _roleRepository.GetByIdAsync(request.RoleId);
            if (role == null)
                throw new Exception("El rol especificado no existe.");

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = hashedPassword,
                RoleId = request.RoleId,
                IsActive = request.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);

            // 🔥 Publicar evento para que se almacene en MongoDB
            await _mediator.Publish(new UserCreatedEvent
            {
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Role = new RoleCreatedEvent // Se envía el rol completo al evento
                {
                    RoleId = role.Id,
                    Name = role.Name,
                    Description = role.Description
                },
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt
            });

            return user.Id;
        }
    }
}
