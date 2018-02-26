using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploBasicoMVC.Models.Contexto;

namespace EjemploBasicoMVC.Controllers
{
    public class UnidadController : Controller
    {

        private Unidad un = new Unidad();
        // GET: Unidad
        public ActionResult Index(int? id)
        {
            var page = id ?? 1;
            var unidades = un.GetUnidades(page);
            ViewBag.totalPages = un.TotalPages;
            ViewBag.page = page;

            if (Request.IsAjaxRequest())
                return PartialView("ListaUnidades", unidades);

            return View(unidades);
           // return View(Buscar(1));
        }

        //public ActionResult ListaUnidades(int? id)
        //{      
        //    return PartialView(Buscar(id));            
        //}

        //public List<Unidad> Buscar(int? id)
        //{
        //    page = id ?? 1;
        //    var unidades = un.GetUnidades(page);
        //    totalPages = un.TotalPages;
        //    return unidades;
        //}

        // GET: Unidad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Unidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unidad/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Unidad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Unidad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Unidad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Unidad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
