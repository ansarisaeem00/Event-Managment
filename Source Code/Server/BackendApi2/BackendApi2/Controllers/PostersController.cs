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
    public class PostersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Posters
        public IQueryable<Poster> GetPosters()
        {
            return db.Posters;
        }

        // GET: api/Posters/5
        [ResponseType(typeof(Poster))]
        public IHttpActionResult GetPoster(int id)
        {
            Poster poster = db.Posters.Find(id);
            if (poster == null)
            {
                return NotFound();
            }

            return Ok(poster);
        }

        // PUT: api/Posters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPoster(int id, Poster poster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poster.Id)
            {
                return BadRequest();
            }

            db.Entry(poster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosterExists(id))
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

        // POST: api/Posters
        [ResponseType(typeof(Poster))]
        public IHttpActionResult PostPoster(Poster poster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posters.Add(poster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = poster.Id }, poster);
        }

        // DELETE: api/Posters/5
        [ResponseType(typeof(Poster))]
        public IHttpActionResult DeletePoster(int id)
        {
            Poster poster = db.Posters.Find(id);
            if (poster == null)
            {
                return NotFound();
            }

            db.Posters.Remove(poster);
            db.SaveChanges();

            return Ok(poster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PosterExists(int id)
        {
            return db.Posters.Count(e => e.Id == id) > 0;
        }
    }
}