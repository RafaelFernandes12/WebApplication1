using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Context;
using WebApplication1.Models;

namespace WebApplication.DAL.Cadastros
{
    public class UsuarioDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Usuario> ObterUsuariosClassificadosPorUsuarioNome()
        {
            return context.Usuarios.OrderBy(b => b.UsuarioNome);
        }
        public Usuario ObterUsuarioPorId(long id)
        {
            return context.Usuarios.Where(f => f.UsuarioId == id).First();
        }
        public void GravarUsuario(Usuario usuario)
        {
            if (usuario.UsuarioId == 0)
            {
                context.Usuarios.Add(usuario);
            }
            else
            {
                context.Entry(usuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Usuario EliminarUsuarioPorId(long id)
        {
            Usuario usuario = ObterUsuarioPorId(id);
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
            return usuario;
        }
    }
}