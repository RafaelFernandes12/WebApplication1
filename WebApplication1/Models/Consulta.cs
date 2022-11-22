using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Consulta
    {
        public long ConsultaId { get; set; }
        public DateTime Data_Hora{ get; set; }

        public string Sintomas { get; set; }
    }
}