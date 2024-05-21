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
    public class InsurenceTypesController : ApiController
    {
        private db_aa8f93_carinsurenceEntities db = new db_aa8f93_carinsurenceEntities();

        // GET: api/InsurenceTypes
        public IQueryable<InsurenceType> GetInsurenceType()
        {
            return db.InsurenceType;
        }

        // GET: api/InsurenceTypes/5
        [ResponseType(typeof(InsurenceType))]
        public IHttpActionResult GetInsurenceType(int id)
        {
            InsurenceType insurenceType = db.InsurenceType.Find(id);
            if (insurenceType == null)
            {
                return NotFound();
            }

            return Ok(insurenceType);
        }

        // PUT: api/InsurenceTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInsurenceType(int id, InsurenceType insurenceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insurenceType.Id)
            {
                return BadRequest();
            }

            db.Entry(insurenceType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsurenceTypeExists(id))
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

        // POST: api/InsurenceTypes
        [ResponseType(typeof(InsurenceType))]
        public IHttpActionResult PostInsurenceType(InsurenceType insurenceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InsurenceType.Add(insurenceType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = insurenceType.Id }, insurenceType);
        }

        // DELETE: api/InsurenceTypes/5
        [ResponseType(typeof(InsurenceType))]
        public IHttpActionResult DeleteInsurenceType(int id)
        {
            InsurenceType insurenceType = db.InsurenceType.Find(id);
            if (insurenceType == null)
            {
                return NotFound();
            }

            db.InsurenceType.Remove(insurenceType);
            db.SaveChanges();

            return Ok(insurenceType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InsurenceTypeExists(int id)
        {
            return db.InsurenceType.Count(e => e.Id == id) > 0;
        }
    }
}