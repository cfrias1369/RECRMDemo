﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using DBEntities;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4201, https://angularwebapp201909261701.azurewebsites.net", headers: "*", methods: "*")]
    public class ProspectsController : ApiController
    {
        private RECRMEntities db = new RECRMEntities();

        // GET: api/Prospects
        public IQueryable<Prospect> GetProspects()
        {
            return db.Prospects;
        }

        // GET: api/Prospects/5
        [ResponseType(typeof(Prospect))]
        public IHttpActionResult GetProspect(int id)
        {
            Prospect prospect = db.Prospects.Find(id);
            if (prospect == null)
            {
                return NotFound();
            }

            return Ok(prospect);
        }

        // PUT: api/Prospects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProspect(int id, Prospect prospect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prospect.id)
            {
                return BadRequest();
            }

            db.Entry(prospect).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProspectExists(id))
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

        // POST: api/Prospects
        [ResponseType(typeof(Prospect))]
        public IHttpActionResult PostProspect(Prospect prospect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prospects.Add(prospect);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prospect.id }, prospect);
        }

        // DELETE: api/Prospects/5
        [ResponseType(typeof(Prospect))]
        public IHttpActionResult DeleteProspect(int id)
        {
            Prospect prospect = db.Prospects.Find(id);
            if (prospect == null)
            {
                return NotFound();
            }

            db.Prospects.Remove(prospect);
            db.SaveChanges();

            return Ok(prospect);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProspectExists(int id)
        {
            return db.Prospects.Count(e => e.id == id) > 0;
        }
    }
}