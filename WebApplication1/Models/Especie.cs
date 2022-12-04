using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Especie
    {
        [DisplayName("Especie")]
        public long EspecieId { get; set; }
        public string Nome { get; set; }
        
    }
}