using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermercado.Models
{
    public class LoginResponse
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public Usuario? Usuario { get; set; }

        public string Token { get; set; } = string.Empty;
    }
}
