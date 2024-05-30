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
    public class AlignmentController : ControllerBase
    {
        private readonly DBContext _context;

        public AlignmentController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Alignment
        [HttpGet, Route("Get")]
        public async Task<ActionResult<IEnumerable<Alignment>>> GetAlignments()
        {
            var res = await _context.Alignments.ToListAsync();
            return res;
        }

        // GET: api/Alignment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alignment>> GetAlignment(int? id)
        {
            var alignment = await _context.Alignments.FindAsync(id);

            if (alignment == null)
            {
                return NotFound();
            }

            return alignment;
        }

        // PUT: api/Alignment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlignment(int? id, Alignment alignment)
        {
            if (id != alignment.Id)
            {
                return BadRequest();
            }

            _context.Entry(alignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlignmentExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/Alignment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alignment>> PostAlignment(Alignment alignment)
        {
          if (_context.Alignments == null)
          {
              return Problem("Entity set 'DBContext.Alignments'  is null.");
          }
          _context.Alignments.Add(alignment);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetAlignment", new { id = alignment.Id }, alignment);
        }

        // DELETE: api/Alignment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlignment(int? id)
        {
            if (_context.Alignments == null)
            {
                return NotFound();
            }
            var alignment = await _context.Alignments.FindAsync(id);
            if (alignment == null)
            {
                return NotFound();
            }

            _context.Alignments.Remove(alignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlignmentExists(int? id)
        {
            return (_context.Alignments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
