using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class VeterinarioDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Veterinario> ObterVeterinariosClassificadosPorCrmv()
        {
            return context.Veterinarios.OrderBy(b => b.Crmv);
        }
        public Veterinario ObterVeterinarioPorId(long id)
        {
            return context.Veterinarios.Where(f => f.UsuarioId == id).First();
        }
        public void GravarVeterinario(Veterinario cliente)
        {
            if (cliente.UsuarioId == 0)
            {
                context.Veterinarios.Add(cliente);
            }
            else
            {
                context.Entry(cliente).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Veterinario EliminarVeterinarioPorId(long id)
        {
            Veterinario cliente = ObterVeterinarioPorId(id);
            context.Veterinarios.Remove(cliente);
            context.SaveChanges();
            return cliente;
        }
    }
}