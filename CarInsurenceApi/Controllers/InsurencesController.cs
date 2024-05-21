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
    public class InsurencesController : ApiController
    {
        private db_aa8f93_carinsurenceEntities db = new db_aa8f93_carinsurenceEntities();

        // GET: api/Insurences
        public IQueryable<Insurence> GetInsurence()
        {
            return db.Insurence;
        }

        // GET: api/Insurences/5
        [ResponseType(typeof(Insurence))]
        public IHttpActionResult GetInsurence(int id)
        {
            Insurence insurence = db.Insurence.Find(id);
            if (insurence == null)
            {
                return NotFound();
            }

            return Ok(insurence);
        }

        // PUT: api/Insurences/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInsurence(int id, Insurence insurence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insurence.Id)
            {
                return BadRequest();
            }

            db.Entry(insurence).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsurenceExists(id))
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

        // POST: api/Insurences
        [ResponseType(typeof(Insurence))]
        public IHttpActionResult PostInsurence(Insurence insurence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insurence.Add(insurence);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = insurence.Id }, insurence);
        }

        // DELETE: api/Insurences/5
        [ResponseType(typeof(Insurence))]
        public IHttpActionResult DeleteInsurence(int id)
        {
            Insurence insurence = db.Insurence.Find(id);
            if (insurence == null)
            {
                return NotFound();
            }

            db.Insurence.Remove(insurence);
            db.SaveChanges();

            return Ok(insurence);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InsurenceExists(int id)
        {
            return db.Insurence.Count(e => e.Id == id) > 0;
        }
    }
}