using MediatR;

namespace SplitFlow.Application.Commands.Perfilamiento.UsersCommands
{
    public class LoginCommand : IRequest<LoginResult>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResult
    {
        public long IdUser { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
