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
    public class PhotoEmergenciesController : ApiController
    {
        private db_aa8f93_carinsurenceEntities db = new db_aa8f93_carinsurenceEntities();

        // GET: api/PhotoEmergencies
        public IQueryable<PhotoEmergency> GetPhotoEmergency()
        {
            return db.PhotoEmergency;
        }

        // GET: api/PhotoEmergencies/5
        [ResponseType(typeof(PhotoEmergency))]
        public IHttpActionResult GetPhotoEmergency(int id)
        {
            PhotoEmergency photoEmergency = db.PhotoEmergency.Find(id);
            if (photoEmergency == null)
            {
                return NotFound();
            }

            return Ok(photoEmergency);
        }

        // PUT: api/PhotoEmergencies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhotoEmergency(int id, PhotoEmergency photoEmergency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != photoEmergency.Id)
            {
                return BadRequest();
            }

            db.Entry(photoEmergency).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoEmergencyExists(id))
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

        // POST: api/PhotoEmergencies
        [ResponseType(typeof(PhotoEmergency))]
        public IHttpActionResult PostPhotoEmergency(PhotoEmergency photoEmergency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhotoEmergency.Add(photoEmergency);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = photoEmergency.Id }, photoEmergency);
        }

        // DELETE: api/PhotoEmergencies/5
        [ResponseType(typeof(PhotoEmergency))]
        public IHttpActionResult DeletePhotoEmergency(int id)
        {
            PhotoEmergency photoEmergency = db.PhotoEmergency.Find(id);
            if (photoEmergency == null)
            {
                return NotFound();
            }

            db.PhotoEmergency.Remove(photoEmergency);
            db.SaveChanges();

            return Ok(photoEmergency);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhotoEmergencyExists(int id)
        {
            return db.PhotoEmergency.Count(e => e.Id == id) > 0;
        }
    }
}