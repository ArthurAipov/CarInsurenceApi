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
    public class EmergencyApplicationsController : ApiController
    {
        private db_aa8f93_carinsurenceEntities db = new db_aa8f93_carinsurenceEntities();

        // GET: api/EmergencyApplications
        public IQueryable<EmergencyApplication> GetEmergencyApplication()
        {
            return db.EmergencyApplication;
        }

        // GET: api/EmergencyApplications/5
        [ResponseType(typeof(EmergencyApplication))]
        public IHttpActionResult GetEmergencyApplication(int id)
        {
            EmergencyApplication emergencyApplication = db.EmergencyApplication.Find(id);
            if (emergencyApplication == null)
            {
                return NotFound();
            }

            return Ok(emergencyApplication);
        }

        // PUT: api/EmergencyApplications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmergencyApplication(int id, EmergencyApplication emergencyApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emergencyApplication.Id)
            {
                return BadRequest();
            }

            db.Entry(emergencyApplication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmergencyApplicationExists(id))
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

        // POST: api/EmergencyApplications
        [ResponseType(typeof(EmergencyApplication))]
        public IHttpActionResult PostEmergencyApplication(EmergencyApplication emergencyApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmergencyApplication.Add(emergencyApplication);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emergencyApplication.Id }, emergencyApplication);
        }

        // DELETE: api/EmergencyApplications/5
        [ResponseType(typeof(EmergencyApplication))]
        public IHttpActionResult DeleteEmergencyApplication(int id)
        {
            EmergencyApplication emergencyApplication = db.EmergencyApplication.Find(id);
            if (emergencyApplication == null)
            {
                return NotFound();
            }

            db.EmergencyApplication.Remove(emergencyApplication);
            db.SaveChanges();

            return Ok(emergencyApplication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmergencyApplicationExists(int id)
        {
            return db.EmergencyApplication.Count(e => e.Id == id) > 0;
        }
    }
}