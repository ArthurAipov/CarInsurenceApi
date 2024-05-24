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
    public class CascoesController : ApiController
    {
        private db_aa8f93_carinsurenceEntities db = new db_aa8f93_carinsurenceEntities();

        // GET: api/Cascoes
        public IQueryable<Casco> GetCasco()
        {
            return db.Casco;
        }

        // GET: api/Cascoes/5
        [ResponseType(typeof(Casco))]
        public IHttpActionResult GetCasco(int id)
        {
            Casco casco = db.Casco.Find(id);
            if (casco == null)
            {
                return NotFound();
            }

            return Ok(casco);
        }

        // PUT: api/Cascoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCasco(int id, Casco casco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != casco.Id)
            {
                return BadRequest();
            }

            db.Entry(casco).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CascoExists(id))
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

        // POST: api/Cascoes
        [ResponseType(typeof(Casco))]
        public IHttpActionResult PostCasco(Casco casco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Casco.Add(casco);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = casco.Id }, casco);
        }

        // DELETE: api/Cascoes/5
        [ResponseType(typeof(Casco))]
        public IHttpActionResult DeleteCasco(int id)
        {
            Casco casco = db.Casco.Find(id);
            if (casco == null)
            {
                return NotFound();
            }

            db.Casco.Remove(casco);
            db.SaveChanges();

            return Ok(casco);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CascoExists(int id)
        {
            return db.Casco.Count(e => e.Id == id) > 0;
        }
    }
}