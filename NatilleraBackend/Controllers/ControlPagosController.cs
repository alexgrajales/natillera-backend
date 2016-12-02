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
    public class ControlPagosController : ApiController
    {
        private NatilleraBackendContext db = new NatilleraBackendContext();

        // GET: api/ControlPagos
        public IQueryable<ControlPagos> GetControlPagos()
        {
            return db.ControlPagos;
        }

        // GET: api/ControlPagos/5
        [ResponseType(typeof(ControlPagos))]
        public IHttpActionResult GetControlPagos(int id)
        {
            ControlPagos controlPagos = db.ControlPagos.Find(id);
            if (controlPagos == null)
            {
                return NotFound();
            }

            return Ok(controlPagos);
        }

        // PUT: api/ControlPagos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutControlPagos(int id, ControlPagos controlPagos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != controlPagos.Id)
            {
                return BadRequest();
            }

            db.Entry(controlPagos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControlPagosExists(id))
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

        // POST: api/ControlPagos
        [ResponseType(typeof(ControlPagos))]
        public IHttpActionResult PostControlPagos(ControlPagos controlPagos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ControlPagos.Add(controlPagos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = controlPagos.Id }, controlPagos);
        }

        // DELETE: api/ControlPagos/5
        [ResponseType(typeof(ControlPagos))]
        public IHttpActionResult DeleteControlPagos(int id)
        {
            ControlPagos controlPagos = db.ControlPagos.Find(id);
            if (controlPagos == null)
            {
                return NotFound();
            }

            db.ControlPagos.Remove(controlPagos);
            db.SaveChanges();

            return Ok(controlPagos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ControlPagosExists(int id)
        {
            return db.ControlPagos.Count(e => e.Id == id) > 0;
        }
    }
}