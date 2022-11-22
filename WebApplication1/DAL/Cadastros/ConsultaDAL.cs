using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Context;
using WebApplication1.Models;

namespace WebApplication.DAL.Cadastros
{
    public class ConsultaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Consulta> ObterConsultasClassificadosPorSintomas()
        {
            return context.Consultas.OrderBy(b => b.Sintomas);
        }
        public Consulta ObterConsultaPorId(long id)
        {
            return context.Consultas.Where(f => f.ConsultaId == id).First();
        }
        public void GravarConsulta(Consulta consulta)
        {
            if (consulta.ConsultaId == 0)
            {
                context.Consultas.Add(consulta);
            }
            else
            {
                context.Entry(consulta).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Consulta EliminarConsultaPorId(long id)
        {
            Consulta consulta = ObterConsultaPorId(id);
            context.Consultas.Remove(consulta);
            context.SaveChanges();
            return consulta;
        }
    }
}