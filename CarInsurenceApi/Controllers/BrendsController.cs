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
    public class BrendsController : ApiController
    {
        private db_aa8f93_carinsurenceEntities db = new db_aa8f93_carinsurenceEntities();

        // GET: api/Brends
        public IQueryable<Brend> GetBrend()
        {
            return db.Brend;
        }

        // GET: api/Brends/5
        [ResponseType(typeof(Brend))]
        public IHttpActionResult GetBrend(int id)
        {
            Brend brend = db.Brend.Find(id);
            if (brend == null)
            {
                return NotFound();
            }

            return Ok(brend);
        }

        // PUT: api/Brends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBrend(int id, Brend brend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brend.Id)
            {
                return BadRequest();
            }

            db.Entry(brend).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrendExists(id))
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

        // POST: api/Brends
        [ResponseType(typeof(Brend))]
        public IHttpActionResult PostBrend(Brend brend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Brend.Add(brend);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = brend.Id }, brend);
        }

        // DELETE: api/Brends/5
        [ResponseType(typeof(Brend))]
        public IHttpActionResult DeleteBrend(int id)
        {
            Brend brend = db.Brend.Find(id);
            if (brend == null)
            {
                return NotFound();
            }

            db.Brend.Remove(brend);
            db.SaveChanges();

            return Ok(brend);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrendExists(int id)
        {
            return db.Brend.Count(e => e.Id == id) > 0;
        }
    }
}