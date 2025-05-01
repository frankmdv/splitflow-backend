using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Infrastructure.MongoDB.ReadModels.Perfilamiento
{
    public class UserWithoutPasswordDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public RoleReadModel Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
