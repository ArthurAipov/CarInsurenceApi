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
    public class AccidentHistoriesController : ApiController
    {
        private db_aa8f93_carinsurenceEntities db = new db_aa8f93_carinsurenceEntities();

        // GET: api/AccidentHistories
        public IQueryable<AccidentHistory> GetAccidentHistory()
        {
            return db.AccidentHistory;
        }

        // GET: api/AccidentHistories/5
        [ResponseType(typeof(AccidentHistory))]
        public IHttpActionResult GetAccidentHistory(int id)
        {
            AccidentHistory accidentHistory = db.AccidentHistory.Find(id);
            if (accidentHistory == null)
            {
                return NotFound();
            }

            return Ok(accidentHistory);
        }

        // PUT: api/AccidentHistories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccidentHistory(int id, AccidentHistory accidentHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accidentHistory.Id)
            {
                return BadRequest();
            }

            db.Entry(accidentHistory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccidentHistoryExists(id))
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

        // POST: api/AccidentHistories
        [ResponseType(typeof(AccidentHistory))]
        public IHttpActionResult PostAccidentHistory(AccidentHistory accidentHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccidentHistory.Add(accidentHistory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = accidentHistory.Id }, accidentHistory);
        }

        // DELETE: api/AccidentHistories/5
        [ResponseType(typeof(AccidentHistory))]
        public IHttpActionResult DeleteAccidentHistory(int id)
        {
            AccidentHistory accidentHistory = db.AccidentHistory.Find(id);
            if (accidentHistory == null)
            {
                return NotFound();
            }

            db.AccidentHistory.Remove(accidentHistory);
            db.SaveChanges();

            return Ok(accidentHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccidentHistoryExists(int id)
        {
            return db.AccidentHistory.Count(e => e.Id == id) > 0;
        }
    }
}