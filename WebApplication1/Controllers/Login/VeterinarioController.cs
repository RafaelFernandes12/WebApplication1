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
    public class VeterinarioController : Controller
    {
        private VeterinarioDAL clienteDAL = new VeterinarioDAL();

        private ActionResult ObterVisaoVeterinarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Veterinario cliente = clienteDAL.ObterVeterinarioPorId((long)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        private ActionResult GravarVeterinario(Veterinario cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteDAL.GravarVeterinario(cliente);
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }


        public ActionResult Index()
        {
            return View(clienteDAL.ObterVeterinariosClassificadosPorCrmv());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Veterinario cliente)
        {
            return GravarVeterinario(cliente);
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Veterinario cliente)
        {
            return GravarVeterinario(cliente);
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoVeterinarioPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Veterinario cliente = clienteDAL.EliminarVeterinarioPorId(id);
                TempData["Message"] = "Veterinario " + cliente.Crmv.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}