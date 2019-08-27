using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreWebApp.Models;

namespace CoreWebApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectsController : ControllerBase
    {
        private readonly RECRMDBContext _context;

        public ProspectsController(RECRMDBContext context)
        {
            _context = context;
        }

        // GET: api/Prospects
        [HttpGet]
        public IEnumerable<Prospect> GetProspects()
        {
            return _context.Prospects;
        }

        // GET: api/Prospects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProspect([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prospect = await _context.Prospects.FindAsync(id);

            if (prospect == null)
            {
                return NotFound();
            }

            return Ok(prospect);
        }

        // PUT: api/Prospects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProspect([FromRoute] int id, [FromBody] Prospect prospect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prospect.Id)
            {
                return BadRequest();
            }

            _context.Entry(prospect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return NoContent();
        }

        // POST: api/Prospects
        [HttpPost]
        public async Task<IActionResult> PostProspect([FromBody] Prospect prospect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Prospects.Add(prospect);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProspect", new { id = prospect.Id }, prospect);
        }

        // DELETE: api/Prospects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProspect([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prospect = await _context.Prospects.FindAsync(id);
            if (prospect == null)
            {
                return NotFound();
            }

            _context.Prospects.Remove(prospect);
            await _context.SaveChangesAsync();

            return Ok(prospect);
        }

        private bool ProspectExists(int id)
        {
            return _context.Prospects.Any(e => e.Id == id);
        }
    }
}