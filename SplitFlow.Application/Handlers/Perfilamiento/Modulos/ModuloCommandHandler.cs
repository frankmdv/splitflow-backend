using MediatR;
using SplitFlow.Application.Commands.Perfilamiento;
using SplitFlow.Domain.Entities.Perfilamiento;
using SplitFlow.Domain.Events.Perfilamiento;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Perfilamiento.Modulos
{
    public class ModuloCommandHandler : IRequestHandler<CreateModuloCommand, long>
    {
        private readonly IModuloRepository _moduloRepository;
        private readonly IMediator _mediator;

        public ModuloCommandHandler(IModuloRepository moduloRepository, IMediator mediator)
        {
            _moduloRepository = moduloRepository;
            _mediator = mediator;
        }

        public async Task<long> Handle(CreateModuloCommand request, CancellationToken cancellationToken)
        {
            var modulo = new Modulo
            {
                Name = request.Name,
                Level = request.Level,
                Type = request.Type
            };

            await _moduloRepository.AddAsync(modulo);

            //publicar evento
            await _mediator.Publish(new ModuloCreatedEvent
            {
                Id = modulo.Id,
                Name = modulo.Name,
                Level = modulo.Level,
                Type = modulo.Type,
                CreateAt = modulo.CreateAt
            });

            return modulo.Id;
        }
    }
}
