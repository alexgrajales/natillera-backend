using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Natillera.Models;
using NatilleraBackend.Models;

namespace NatilleraBackend.Controllers
{
    public class PrestamoesController : ApiController
    {
        private NatilleraBackendContext db = new NatilleraBackendContext();

        // GET: api/Prestamoes
        public IQueryable<Prestamo> GetPrestamoes()
        {
            return db.Prestamoes;
        }

        // GET: api/Prestamoes/5
        [ResponseType(typeof(Prestamo))]
        public IHttpActionResult GetPrestamo(int id)
        {
            Prestamo prestamo = db.Prestamoes.Find(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return Ok(prestamo);
        }

        // PUT: api/Prestamoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrestamo(int id, Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestamo.Id)
            {
                return BadRequest();
            }

            db.Entry(prestamo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestamoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Prestamoes
        [ResponseType(typeof(Prestamo))]
        public IHttpActionResult PostPrestamo(Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prestamoes.Add(prestamo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prestamo.Id }, prestamo);
        }

        // DELETE: api/Prestamoes/5
        [ResponseType(typeof(Prestamo))]
        public IHttpActionResult DeletePrestamo(int id)
        {
            Prestamo prestamo = db.Prestamoes.Find(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            db.Prestamoes.Remove(prestamo);
            db.SaveChanges();

            return Ok(prestamo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrestamoExists(int id)
        {
            return db.Prestamoes.Count(e => e.Id == id) > 0;
        }
    }
}