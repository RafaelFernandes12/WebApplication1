using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Usuario
    {
        public long UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}