using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab78.Data;
using Lab78.Models;

namespace Lab78.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeContoller : ControllerBase
    {
        private readonly DBContext _context;

        public AttributeContoller(DBContext context)
        {
            _context = context;
        }

        // GET: api/AttributeContoller
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attribute_db>>> GetAttributes()
        {
          if (_context.Attributes == null)
          {
              return NotFound();
          }
            return await _context.Attributes.ToListAsync();
        }

        // GET: api/AttributeContoller/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attribute_db>> GetAttribute_db(int? id)
        {
          if (_context.Attributes == null)
          {
              return NotFound();
          }
            var attribute_db = await _context.Attributes.FindAsync(id);

            if (attribute_db == null)
            {
                return NotFound();
            }

            return attribute_db;
        }

        // PUT: api/AttributeContoller/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttribute_db(int? id, Attribute_db attribute_db)
        {
            if (id != attribute_db.Id)
            {
                return BadRequest();
            }

            _context.Entry(attribute_db).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Attribute_dbExists(id))
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

        // POST: api/AttributeContoller
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Attribute_db>> PostAttribute_db(Attribute_db attribute_db)
        {
          if (_context.Attributes == null)
          {
              return Problem("Entity set 'DBContext.Attributes'  is null.");
          }
            _context.Attributes.Add(attribute_db);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttribute_db", new { id = attribute_db.Id }, attribute_db);
        }

        // DELETE: api/AttributeContoller/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttribute_db(int? id)
        {
            if (_context.Attributes == null)
            {
                return NotFound();
            }
            var attribute_db = await _context.Attributes.FindAsync(id);
            if (attribute_db == null)
            {
                return NotFound();
            }

            _context.Attributes.Remove(attribute_db);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Attribute_dbExists(int? id)
        {
            return (_context.Attributes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
