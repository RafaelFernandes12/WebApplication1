using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.DAL;
using System.Net;

namespace WebApplication1.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        private ActionResult ObterVisaoClientePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Cliente cliente = clienteDAL.ObterClientePorId((long)id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        private ActionResult GravarCliente(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteDAL.GravarCliente(cliente);
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
            return View(clienteDAL.ObterClientesClassificadosPorCpf());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            return GravarCliente(cliente);
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoClientePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            return GravarCliente(cliente);
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
                Cliente cliente = clienteDAL.EliminarClientePorId(id);
                TempData["Message"] = "Cliente " + cliente.Cpf.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}