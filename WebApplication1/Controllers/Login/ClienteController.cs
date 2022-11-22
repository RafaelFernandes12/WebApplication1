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
    public class ClienteController : Controller
    {
        private ClienteDAL usuarioDAL = new ClienteDAL();

        private ActionResult ObterVisaoClientePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Cliente usuario = usuarioDAL.ObterClientePorId((long)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        private ActionResult GravarCliente(Cliente usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioDAL.GravarCliente(usuario);
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
            return View(usuarioDAL.ObterClientesClassificadosPorCpf());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente usuario)
        {
            return GravarCliente(usuario);
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoClientePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente usuario)
        {
            return GravarCliente(usuario);
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoClientePorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoClientePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Cliente usuario = usuarioDAL.EliminarClientePorId(id);
                TempData["Message"] = "Cliente " + usuario.Cpf.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}