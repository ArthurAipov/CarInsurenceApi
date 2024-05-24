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
using CarInsurenceApi.Models;

namespace CarInsurenceApi.Controllers
{
    public class OsagoesController : ApiController
    {
        private db_aa8f93_carinsurenceEntities db = new db_aa8f93_carinsurenceEntities();

        // GET: api/Osagoes
        public IQueryable<Osago> GetOsago()
        {
            return db.Osago;
        }

        // GET: api/Osagoes/5
        [ResponseType(typeof(Osago))]
        public IHttpActionResult GetOsago(int id)
        {
            Osago osago = db.Osago.Find(id);
            if (osago == null)
            {
                return NotFound();
            }

            return Ok(osago);
        }

        // PUT: api/Osagoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOsago(int id, Osago osago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != osago.Id)
            {
                return BadRequest();
            }

            db.Entry(osago).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OsagoExists(id))
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

        // POST: api/Osagoes
        [ResponseType(typeof(Osago))]
        public IHttpActionResult PostOsago(Osago osago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Osago.Add(osago);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = osago.Id }, osago);
        }

        // DELETE: api/Osagoes/5
        [ResponseType(typeof(Osago))]
        public IHttpActionResult DeleteOsago(int id)
        {
            Osago osago = db.Osago.Find(id);
            if (osago == null)
            {
                return NotFound();
            }

            db.Osago.Remove(osago);
            db.SaveChanges();

            return Ok(osago);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OsagoExists(int id)
        {
            return db.Osago.Count(e => e.Id == id) > 0;
        }
    }
}