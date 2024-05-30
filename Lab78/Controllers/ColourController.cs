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
    public class ColourController : ControllerBase
    {
        private readonly DBContext _context;

        public ColourController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Colour
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colour>>> GetColours()
        {
          if (_context.Colours == null)
          {
              return NotFound();
          }
            return await _context.Colours.ToListAsync();
        }

        // GET: api/Colour/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colour>> GetColour(int? id)
        {
          if (_context.Colours == null)
          {
              return NotFound();
          }
            var colour = await _context.Colours.FindAsync(id);

            if (colour == null)
            {
                return NotFound();
            }

            return colour;
        }

        // PUT: api/Colour/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColour(int? id, Colour colour)
        {
            if (id != colour.Id)
            {
                return BadRequest();
            }

            _context.Entry(colour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColourExists(id))
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

        // POST: api/Colour
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Colour>> PostColour(Colour colour)
        {
          if (_context.Colours == null)
          {
              return Problem("Entity set 'DBContext.Colours'  is null.");
          }
            _context.Colours.Add(colour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColour", new { id = colour.Id }, colour);
        }

        // DELETE: api/Colour/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColour(int? id)
        {
            if (_context.Colours == null)
            {
                return NotFound();
            }
            var colour = await _context.Colours.FindAsync(id);
            if (colour == null)
            {
                return NotFound();
            }

            _context.Colours.Remove(colour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColourExists(int? id)
        {
            return (_context.Colours?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
