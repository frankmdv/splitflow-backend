using SplitFlow.Domain.Entities.Gestion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFlow.Domain.Entities.Perfilamiento
{
    [Table("User", Schema = "PER")]
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public long RoleId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual Role Role { get; set; }
        public List<Cuenta> ListaUsuarioCuenta { get; set; } = new List<Cuenta>();
        public List<Presupuesto> ListaPresupuestosUsuarios { get; set; } = new List<Presupuesto>();
    }
}
