using Lab78.Data;
using Lab78.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab78.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroPowerController : ControllerBase
    {
        private readonly DBContext _context;

        public HeroPowerController(DBContext context)
        {
            _context = context;
        }

        // GET: api/HeroPower
        [HttpGet]
        public async Task<List<Hero_power>> GetHeroPowers()
        {
            return await _context.HeroPowers.ToListAsync();
        }
        

        // PUT: api/HeroPower/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{hero_id} & {power_id}")]
        public async Task<IActionResult> PutHeroPower(int? hero_id, int? power_id, Hero_power power)
        {
            if (await _context.HeroPowers.FindAsync(hero_id, power_id) == null)
            {
                return NotFound();
            }
            try
            {
                await PostHeroPower(new Hero_power()
                {
                    hero_id = power.hero_id, power_id = power.power_id
                });
                await DeleteHeroPower(hero_id, power_id);
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroPowersExists(power.hero_id, power.power_id))
                {
                    return NotFound();
                }
                return Conflict();
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/HeroPower
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hero_power>> PostHeroPower(Hero_power power)
        {
          if (_context.HeroPowers == null)
          {
              return Problem("Entity set 'DBContext.Publishers'  is null.");
          }
            _context.HeroPowers.Add(power);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeroPowers", new { hero_id = power.hero_id, power_id = power.power_id }, power);
        }

        // DELETE: api/HeroPower/5
        [HttpDelete("{hero_id} & {power_id}")]
        public async Task<IActionResult> DeleteHeroPower(int? hero_id, int? power_id)
        {
            if (_context.HeroPowers == null)
            {
                return NotFound();
            }
            var attr = await _context.HeroPowers.FindAsync(hero_id, power_id);
            if (attr == null)
            {
                return NotFound();
            }

            _context.HeroPowers.Remove(attr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroPowersExists(int? hero_id, int? power_id)
        {
            return (_context.HeroPowers?.Any(e => (e.hero_id.Equals(hero_id)) && (e.power_id.Equals(power_id)))).GetValueOrDefault();
        }
    }
}