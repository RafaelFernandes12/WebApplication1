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
    public class ConsultaController : Controller
    {
        private ConsultaDAL consultaDAL = new ConsultaDAL();

        private ActionResult ObterVisaoConsultaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Consulta consulta = consultaDAL.ObterConsultaPorId((long)id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        private ActionResult GravarConsulta(Consulta consulta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    consultaDAL.GravarConsulta(consulta);
                    return RedirectToAction("Index");
                }
                return View(consulta);
            }
            catch
            {
                return View(consulta);
            }
        }


        public ActionResult Index()
        {
            return View(consultaDAL.ObterConsultasClassificadosPorSintomas());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consulta consulta)
        {
            return GravarConsulta(consulta);
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoConsultaPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Consulta consulta)
        {
            return GravarConsulta(consulta);
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoConsultaPorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoConsultaPorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Consulta consulta = consultaDAL.EliminarConsultaPorId(id);
                TempData["Message"] = "Consulta " + consulta.Sintomas.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}