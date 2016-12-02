using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Natillera.Models;

namespace Natillera.Controllers
{
    public class ControlPagosFindController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ControlPagosFind
        public ActionResult Index(int? id)
        {            
            var controlPagos = db.ControlPagos.Include(c => c.usuario);
            ViewBag.usuarioID = new SelectList(db.Usuarios, "Id", "Nombre");
            ViewBag.iduser = new int();
            if (ViewBag.usuarioID.DataGroupField != null)
               id = ViewBag.usuarioID.Id;
            if (id.Equals(null))
                id = 1;
            var obj = db.ControlPagos.SqlQuery("select * from controlPagos where usuarioId ="+ id).ToList<ControlPagos>();
            return View(obj);
        }

        // GET: ControlPagosFind/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlPagos controlPagos = db.ControlPagos.Find(id);           
            if (controlPagos == null)
            {
                return HttpNotFound();
            }
            return View(controlPagos);
        }

        // GET: ControlPagosFind/Create
        public ActionResult Create()
        {
            ViewBag.usuarioID = new SelectList(db.Usuarios, "Id", "Nombre");
            return View();
        }

        // POST: ControlPagosFind/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Valor,usuarioID")] ControlPagos controlPagos)
        {
            if (ModelState.IsValid)
            {
                db.ControlPagos.Add(controlPagos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usuarioID = new SelectList(db.Usuarios, "Id", "Nombre", controlPagos.usuarioID);
            return View(controlPagos);
        }

        // GET: ControlPagosFind/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlPagos controlPagos = db.ControlPagos.Find(id);
            if (controlPagos == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuarioID = new SelectList(db.Usuarios, "Id", "Nombre", controlPagos.usuarioID);
            return View(controlPagos);
        }

        // POST: ControlPagosFind/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Valor,usuarioID")] ControlPagos controlPagos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(controlPagos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usuarioID = new SelectList(db.Usuarios, "Id", "Nombre", controlPagos.usuarioID);
            return View(controlPagos);
        }

        // GET: ControlPagosFind/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ControlPagos controlPagos = db.ControlPagos.Find(id);
            if (controlPagos == null)
            {
                return HttpNotFound();
            }
            return View(controlPagos);
        }

        // POST: ControlPagosFind/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ControlPagos controlPagos = db.ControlPagos.Find(id);
            db.ControlPagos.Remove(controlPagos);
            db.SaveChanges();
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
