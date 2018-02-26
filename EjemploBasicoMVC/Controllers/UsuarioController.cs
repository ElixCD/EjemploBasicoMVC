using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EjemploBasicoMVC.Models.Contexto;

namespace EjemploBasicoMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private ContextModel context = new ContextModel();
        // GET: Usuario
        public async Task<ActionResult> Index()
        {         
            return View(await context.Usuario.ToListAsync());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (var strd = new Models.Contexto.ContextModel())
                {
                    using (var tr = strd.Database.BeginTransaction())
                    {
                        SqlParameter clave = new SqlParameter("@clave", Request.Form["clave"]);
                        SqlParameter nombre = new SqlParameter("@nombre", Request.Form["nombre"]);
                        SqlParameter contrasena = new SqlParameter("@contrasena", Request.Form["contrasena"]);
                        strd.Database.ExecuteSqlCommand("UsuarioAlta @clave @nombre @contrasena", clave,nombre,contrasena);

                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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
