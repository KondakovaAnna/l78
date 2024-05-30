using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab78.Data;
using Lab78.Models;
using Microsoft.AspNetCore.Authorization;

namespace Lab78.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : ControllerBase
    {
        private readonly DBContext _context;

        public SuperheroController(DBContext context)
        {
            _context = context;
        }

        private bool SuperheroExists(int id)
        {
            return (_context.Superheroes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        
        // GET: api/Superhero
        [Authorize]
        [HttpGet, Route("Get")]
        public async Task<ActionResult<IEnumerable<Superhero>>> GetSuperheroes()
        {
            return await _context.Superheroes.ToListAsync();
        }

        // POST: api/Superhero
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "admin")]
        [HttpPost, Route("Post")]
        public async Task<ActionResult<Superhero>> PostSuperhero(Superhero superhero)
        {
            if (_context.Superheroes == null)
            {
                return Problem("Entity set 'DBContext.Superheroes'  is null.");
            }

            _context.Superheroes.Add(superhero);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (SuperheroExists(
                    superhero.Id))
                {
                    return Conflict();
                }
            }
            return CreatedAtAction("GetSuperheroes", new { id = superhero.Id }, superhero);
        }

        // PUT: api/Superhero
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperhero(int id, Superhero superhero)
        {
            if (id != superhero.Id)
            {
                return BadRequest();
            }

            var hero = await _context.Superheroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }
            hero.superhero_name = superhero.superhero_name;
            hero.full_name = superhero.full_name;
            hero.gender_id = superhero.gender_id;
            hero.eye_colour_id = superhero.eye_colour_id;
            hero.hair_colour_id = superhero.hair_colour_id;
            hero.skin_colour_id = superhero.skin_colour_id;
            hero.race_id = superhero.race_id;
            hero.publisher_id = superhero.publisher_id;
            hero.alignment_id = superhero.alignment_id;
            hero.height_cm = superhero.height_cm;
            hero.weight_kg = superhero.weight_kg;

            _context.Entry(hero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperheroExists(id))
                {
                    return NotFound();
                }

                return Conflict();
            }

            return NoContent();
        }

        // DELETE: api/Superhero/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperhero(int? id)
        {
            if (_context.Superheroes == null)
            {
                return NotFound();
            }

            var superhero = await _context.Superheroes.FindAsync(id);
            if (superhero == null)
            {
                return NotFound();
            }

            _context.Superheroes.Remove(superhero);
            // var attr = await _context.HeroAttributes.First
            // Console.WriteLine(attr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuperheroExists(int? id)
        {
            return (_context.Superheroes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}