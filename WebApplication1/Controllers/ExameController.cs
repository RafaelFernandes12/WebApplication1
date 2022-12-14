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
    public class ExameController : Controller
    {
        private ExameDAL exameDAL = new ExameDAL();

        private ActionResult ObterVisaoExamePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Exame exame = exameDAL.ObterExamePorId((long)id);
            if (exame == null)
            {
                return HttpNotFound();
            }
            return View(exame);
        }

        private ActionResult GravarExame(Exame exame)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    exameDAL.GravarExame(exame);
                    return RedirectToAction("Index");
                }
                return View(exame);
            }
            catch
            {
                return View(exame);
            }
        }


        public ActionResult Index()
        {
            return View(exameDAL.ObterExamesClassificadosPorDescricao());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exame exame)
        {
            return GravarExame(exame);
        }

        public ActionResult Edit(long? id)
        {
            return ObterVisaoExamePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Exame exame)
        {
            return GravarExame(exame);
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoExamePorId(id);
        }

        public ActionResult Delete(long? id)
        {
            return ObterVisaoExamePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Exame exame = exameDAL.EliminarExamePorId(id);
                TempData["Message"] = "Exame " + exame.Descricao.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}