using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication.DAL.Cadastros;
using System.Net;

namespace WebApplication.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        private ActionResult ObterVisaoUsuarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuarioDAL.ObterUsuarioPorId((long)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        private ActionResult GravarUsuario(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioDAL.GravarUsuario(usuario);
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch
            {
                return View(usuario);
            }
        }


        public ActionResult Index()
        {
            return View(usuarioDAL.ObterUsuariosClassificadosPorUsuarioNome());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            return GravarUsuario(usuario);
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoUsuarioPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            return GravarUsuario(usuario);
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoUsuarioPorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoUsuarioPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Usuario usuario = usuarioDAL.EliminarUsuarioPorId(id);
                TempData["Message"] = "Usuario " + usuario.UsuarioNome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}