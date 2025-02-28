using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Application.Commands
{
    public class CreateUserCommand : IRequest<long>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
