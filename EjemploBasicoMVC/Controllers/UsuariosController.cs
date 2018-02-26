using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EjemploBasicoMVC.Models.Contexto;
using System.Data.SqlClient;

namespace EjemploBasicoMVC.Controllers
{
    public class UsuariosController : Controller
    {
        private ContextModel db = new ContextModel();

        // GET: Usuarios
        public async Task<ActionResult> Index()
        {
            return View(await db.Usuario.ToListAsync());
        }
        
        // GET: Usuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,clave,nombre,contrasena")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await usuario.Salvar();                
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,clave,nombre,contrasena,activo,fechaAlta,horaAlta,fechaBaja,horaBaja")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                await usuario.Editar();
                //using (var trn = db.Database.BeginTransaction())
                //{
                //    SqlParameter id = new SqlParameter() { ParameterName = "@id", Value = usuario.id };
                //    SqlParameter clave = new SqlParameter() { ParameterName = "@clave", Value = usuario.clave };
                //    SqlParameter nombre = new SqlParameter() { ParameterName = "@nombre", Value = usuario.nombre };
                //    SqlParameter contrasena = new SqlParameter() { ParameterName = "@contrasena", Value = usuario.contrasena };
                //    SqlParameter activo = new SqlParameter() { ParameterName = "@activo", Value = usuario.activo };

                //    try
                //    {
                //        await db.Database.ExecuteSqlCommandAsync("UsuarioActualiza @id, @clave, @nombre, @contrasena", id, clave, nombre, contrasena);
                //        trn.Commit();
                //    }
                //    catch (Exception)
                //    {
                //        trn.Rollback();
                //        throw;
                //    }
                //}

                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Usuario usuario = await db.Usuario.FindAsync(id);
            db.Usuario.Remove(usuario);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
