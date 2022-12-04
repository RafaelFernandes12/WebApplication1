using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Cliente : Usuario
    {
        public string Cpf { get; set; }
    }
}