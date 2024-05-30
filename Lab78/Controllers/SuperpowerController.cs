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
    public class SuperpowerController : ControllerBase
    {
        private readonly DBContext _context;

        public SuperpowerController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Superpower
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Superpower>>> GetSuperpowers()
        {
          if (_context.Superpowers == null)
          {
              return NotFound();
          }
            return await _context.Superpowers.ToListAsync();
        }

        // GET: api/Superpower/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Superpower>> GetSuperpower(int? id)
        {
          if (_context.Superpowers == null)
          {
              return NotFound();
          }
            var superpower = await _context.Superpowers.FindAsync(id);

            if (superpower == null)
            {
                return NotFound();
            }

            return superpower;
        }

        // PUT: api/Superpower/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperpower(int? id, Superpower superpower)
        {
            if (id != superpower.Id)
            {
                return BadRequest();
            }

            _context.Entry(superpower).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperpowerExists(id))
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

        // POST: api/Superpower
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Superpower>> PostSuperpower(Superpower superpower)
        {
          if (_context.Superpowers == null)
          {
              return Problem("Entity set 'DBContext.Superpowers'  is null.");
          }
            _context.Superpowers.Add(superpower);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuperpower", new { id = superpower.Id }, superpower);
        }

        // DELETE: api/Superpower/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperpower(int? id)
        {
            if (_context.Superpowers == null)
            {
                return NotFound();
            }
            var superpower = await _context.Superpowers.FindAsync(id);
            if (superpower == null)
            {
                return NotFound();
            }

            _context.Superpowers.Remove(superpower);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuperpowerExists(int? id)
        {
            return (_context.Superpowers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
