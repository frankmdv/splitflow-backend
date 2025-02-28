using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Events
{
    public class UserCreatedEvent : INotification
    {
        public long UserId { get; set; }
        public string Username { get; set; } 
        public string Email { get; set; }
        public string PasswordHash { get; set; } 
        public long RoleId { get; set; } 
        public string RoleName { get; set; } 
        public bool IsActive { get; set; } = true; 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
