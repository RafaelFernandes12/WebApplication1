using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class CheckBoxViewModel
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public bool Checked { get; set; }
    }
}