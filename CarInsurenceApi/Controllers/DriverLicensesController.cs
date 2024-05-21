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
    public class DriverLicensesController : ApiController
    {
        private db_aa8f93_carinsurenceEntities db = new db_aa8f93_carinsurenceEntities();

        // GET: api/DriverLicenses
        public IQueryable<DriverLicense> GetDriverLicense()
        {
            return db.DriverLicense;
        }

        // GET: api/DriverLicenses/5
        [ResponseType(typeof(DriverLicense))]
        public IHttpActionResult GetDriverLicense(int id)
        {
            DriverLicense driverLicense = db.DriverLicense.Find(id);
            if (driverLicense == null)
            {
                return NotFound();
            }

            return Ok(driverLicense);
        }

        // PUT: api/DriverLicenses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriverLicense(int id, DriverLicense driverLicense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driverLicense.Id)
            {
                return BadRequest();
            }

            db.Entry(driverLicense).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverLicenseExists(id))
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

        // POST: api/DriverLicenses
        [ResponseType(typeof(DriverLicense))]
        public IHttpActionResult PostDriverLicense(DriverLicense driverLicense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DriverLicense.Add(driverLicense);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = driverLicense.Id }, driverLicense);
        }

        // DELETE: api/DriverLicenses/5
        [ResponseType(typeof(DriverLicense))]
        public IHttpActionResult DeleteDriverLicense(int id)
        {
            DriverLicense driverLicense = db.DriverLicense.Find(id);
            if (driverLicense == null)
            {
                return NotFound();
            }

            db.DriverLicense.Remove(driverLicense);
            db.SaveChanges();

            return Ok(driverLicense);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DriverLicenseExists(int id)
        {
            return db.DriverLicense.Count(e => e.Id == id) > 0;
        }
    }
}