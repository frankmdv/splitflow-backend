using MediatR;
using SplitFlow.Application.Commands.Gestion.GastoCommands;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Gestion.GastoHandlers
{
    public class GastoCommandHandler : IRequestHandler<CreateGastoCommand, long>
    {
        private readonly IParGenYEspeRepository _parGenYEspeRepository;
        private readonly IMediator _mediator;
        private readonly IPresupuestoRepository _presupuestoRepository;

        public GastoCommandHandler(
            IParGenYEspeRepository parGenYEspeRepository, 
            IMediator mediator, 
            IPresupuestoRepository presupuestoRepository)
        {
            _parGenYEspeRepository = parGenYEspeRepository;
            _mediator = mediator;
            _presupuestoRepository = presupuestoRepository;
        }

        public Task<long> Handle(CreateGastoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
