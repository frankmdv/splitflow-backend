using MediatR;
using SplitFlow.Application.Commands.Gestion.MovimientoCreditoCommands;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Gestion.MovimientosCreditoHandlers
{
    public class MovCreditoCommandHandler : IRequestHandler<CreateMovimientoCreditoCommand, long>
    {
        private readonly IMediator _mediator;
        private readonly IParGenYEspeRepository _parGenYEspeRepository;
        private readonly IMovimientoCreditoRepository _movimientoCreditoRepository;
        private readonly ICreditoRepository _creditoRepository;

        public MovCreditoCommandHandler(
            IMediator mediator, 
            IParGenYEspeRepository parGenYEspeRepository, 
            IMovimientoCreditoRepository movimientoCreditoRepository, 
            ICreditoRepository creditoRepository)
        {
            _mediator = mediator;
            _parGenYEspeRepository = parGenYEspeRepository;
            _movimientoCreditoRepository = movimientoCreditoRepository;
            _creditoRepository = creditoRepository;
        }

        public Task<long> Handle(CreateMovimientoCreditoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
