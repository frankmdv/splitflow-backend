using Azure;
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

namespace SplitFlow.Application.Handlers.Parametrizacion.ParEspe
{
    public class ParEspecificoCommandHandler : IRequestHandler<CreateParEspecificoCommand, long>
    {
        private readonly IParGenYEspeRepository _parGenyEsperepository;
        private readonly IMediator _mediator;

        public ParEspecificoCommandHandler(IParGenYEspeRepository parGenyEsperepository, IMediator mediator)
        {
            _parGenyEsperepository = parGenyEsperepository;
            _mediator = mediator;
        }

        public async Task<long> Handle(CreateParEspecificoCommand request, CancellationToken cancellationToken)
        {
            var parEsp = new ParametroEspecifico
            {
                Nombre = request.Nombre,
                Estado = request.Estado,
                IdParGeneral = request.ParGenId,
                CreateAt = DateTime.Now
            };

            await _parGenyEsperepository.AddParEspecifico(parEsp);

            await _mediator.Publish(new ParEspecificoCreatedEvent
            {
                ParEspeId = parEsp.Id,
                Nombre = parEsp.Nombre,
                Estado = parEsp.Estado,
                IdParGeneral = parEsp.IdParGeneral,
                CreateAt = DateTime.Now
            });

            return parEsp.Id;
        }
    }
}
