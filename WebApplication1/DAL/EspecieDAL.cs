using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class EspecieDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Especie> ObterEspeciesClassificadosPorEspecieNome()
        {
            return context.Especies.OrderBy(b => b.Nome);
        }
        public Especie ObterEspeciePorId(long id)
        {
            return context.Especies.Where(f => f.EspecieId == id).First();
        }
        public void GravarEspecie(Especie especie)
        {
            if (especie.EspecieId == 0)
            {
                context.Especies.Add(especie);
            }
            else
            {
                context.Entry(especie).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Especie EliminarEspeciePorId(long id)
        {
            Especie especie = ObterEspeciePorId(id);
            context.Especies.Remove(especie);
            context.SaveChanges();
            return especie;
        }
    }
}