using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Models
{
    public class Consulta
    {
        public long ConsultaId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data_hora { get; set; }
        public string Sintomas { get; set; }
        public List<CheckBoxViewModel> ExamesCK { get; set; }
        public virtual ICollection<Exame> Exames { get; set; }
    }
}