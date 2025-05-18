using MediatR;
using SplitFlow.Application.Commands.Gestion.PresupuestoCommands;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Gestion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Parametrizacion;
using SplitFlow.Infrastructure.SqlServer.Interfaces.Perfilamiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Handlers.Gestion.PresupuestoHandlers
{
    public class PresupuestoCommandHandler : IRequestHandler<CreatePresupuestoCommand, long>
    {
        private readonly IUserRepository _userRepository;
        private readonly IParGenYEspeRepository _parGenYEspeRepository;
        private readonly IMediator _mediator;
        private readonly IPresupuestoRepository _presupuestoRepository;

        public PresupuestoCommandHandler(
            IUserRepository userRepository, 
            IParGenYEspeRepository parGenYEspeRepository, 
            IMediator mediator, 
            IPresupuestoRepository presupuestoRepository)
        {
            _userRepository = userRepository;
            _parGenYEspeRepository = parGenYEspeRepository;
            _mediator = mediator;
            _presupuestoRepository = presupuestoRepository;
        }

        public Task<long> Handle(CreatePresupuestoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
