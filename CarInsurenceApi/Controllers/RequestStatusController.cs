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
    public class RequestStatusController : ApiController
    {
        private db_aa8f93_carinsurenceEntities db = new db_aa8f93_carinsurenceEntities();

        // GET: api/RequestStatus
        public IQueryable<RequestStatus> GetRequestStatus()
        {
            return db.RequestStatus;
        }

        // GET: api/RequestStatus/5
        [ResponseType(typeof(RequestStatus))]
        public IHttpActionResult GetRequestStatus(int id)
        {
            RequestStatus requestStatus = db.RequestStatus.Find(id);
            if (requestStatus == null)
            {
                return NotFound();
            }

            return Ok(requestStatus);
        }

        // PUT: api/RequestStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequestStatus(int id, RequestStatus requestStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requestStatus.Id)
            {
                return BadRequest();
            }

            db.Entry(requestStatus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestStatusExists(id))
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

        // POST: api/RequestStatus
        [ResponseType(typeof(RequestStatus))]
        public IHttpActionResult PostRequestStatus(RequestStatus requestStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestStatus.Add(requestStatus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = requestStatus.Id }, requestStatus);
        }

        // DELETE: api/RequestStatus/5
        [ResponseType(typeof(RequestStatus))]
        public IHttpActionResult DeleteRequestStatus(int id)
        {
            RequestStatus requestStatus = db.RequestStatus.Find(id);
            if (requestStatus == null)
            {
                return NotFound();
            }

            db.RequestStatus.Remove(requestStatus);
            db.SaveChanges();

            return Ok(requestStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestStatusExists(int id)
        {
            return db.RequestStatus.Count(e => e.Id == id) > 0;
        }
    }
}