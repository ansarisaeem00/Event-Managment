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
using BackendApi2.Models;

namespace BackendApi2.Controllers
{
    public class DeatailsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Deatails
        public IQueryable<Deatails> GetDeatails()
        {
            return db.Deatails;
        }

        // GET: api/Deatails/5
        [ResponseType(typeof(Deatails))]
        public IHttpActionResult GetDeatails(int id)
        {
            Deatails deatails = db.Deatails.Find(id);
            if (deatails == null)
            {
                return NotFound();
            }

            return Ok(deatails);
        }

        // PUT: api/Deatails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeatails(int id, Deatails deatails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deatails.Id)
            {
                return BadRequest();
            }

            db.Entry(deatails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeatailsExists(id))
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

        // POST: api/Deatails
        [ResponseType(typeof(Deatails))]
        public IHttpActionResult PostDeatails(Deatails deatails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Deatails.Add(deatails);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = deatails.Id }, deatails.Id);
            
        }

        // DELETE: api/Deatails/5
        [ResponseType(typeof(Deatails))]
        public IHttpActionResult DeleteDeatails(int id)
        {
            Deatails deatails = db.Deatails.Find(id);
            if (deatails == null)
            {
                return NotFound();
            }

            db.Deatails.Remove(deatails);
            db.SaveChanges();

            return Ok(deatails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeatailsExists(int id)
        {
            return db.Deatails.Count(e => e.Id == id) > 0;
        }
    }
}