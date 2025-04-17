using MediatR;
using SplitFlow.Application.Commands.Parametrizacion;
using SplitFlow.Domain.Entities.Parametrizacion;
using SplitFlow.Domain.Events.Parametrizacion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Parametrizacion.ParGen
{
    public class ParGeneralCommandHandler : IRequestHandler<CreateParGeneralCommand, long>
    {
        private readonly IParGenYEspeRepository _parGenyEsperepository;
        private readonly IMediator _mediator;

        public ParGeneralCommandHandler(IParGenYEspeRepository parGenyEsperepository, IMediator mediator)
        {
            _parGenyEsperepository = parGenyEsperepository;
            _mediator = mediator;
        }

        public async Task<long> Handle(CreateParGeneralCommand request, CancellationToken cancellationToken)
        {
            var parGen = new ParametroGeneral
            {
                Nombre = request.Nombre,
                Estado = request.Estado,
                CreateAt = DateTime.Now
            };

            await _parGenyEsperepository.AddParGeneral(parGen);

            await _mediator.Publish(new ParGeneralCreatedEvent
            {
                ParGenId = parGen.Id,
                Nombre = parGen.Nombre,
                Estado = parGen.Estado,
                CreateAt = DateTime.Now
            });

            return parGen.Id;
        }
    }
}
