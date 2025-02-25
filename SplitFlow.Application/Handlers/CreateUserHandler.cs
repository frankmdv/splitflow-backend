using MediatR;
using SplitFlow.Application.Commands;
using SplitFlow.Domain.Entities;
using SplitFlow.Domain.Events;
using SplitFlow.Infrastructure.SqlServer.Data;


namespace SplitFlow.Application.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly MyDbContext _dbContext;
        private readonly IMediator _mediator;

        public CreateUserHandler(MyDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { Name = request.Name, Email = request.Email };
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            await _mediator.Publish(new UserCreatedEvent
            {
                UserId = user.Id,
                Name = user.Name,
                Email = user.Email
            });

            return user.Id;
        }
    }
}
