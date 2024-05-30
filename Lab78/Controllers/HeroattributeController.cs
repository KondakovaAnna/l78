using Lab78.Data;
using Lab78.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab78.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroattributeController : ControllerBase
    {
        private readonly DBContext _context;

        public HeroattributeController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Heroattribute
        [HttpGet]
        public async Task<List<Hero_attribute>> GetHeroAttributes()
        {
            return await _context.HeroAttributes.ToListAsync();
        }
        

        // PUT: api/Heroattribute/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{hero_id} & {attribute_id}")]
        public async Task<IActionResult> PutHeroAttribute(int? hero_id, int? attribute_id, int? attr_value, Hero_attribute attr)
        {
            if (await _context.HeroAttributes.FindAsync(hero_id, attribute_id) == null)
            {
                return NotFound();
            }
            try
            {
                await PostHeroAttribute(new Hero_attribute()
                {
                    hero_id = attr.hero_id, attribute_id = attr.attribute_id, attribute_value = attr_value
                });
                await DeleteHeroAttribute(hero_id, attribute_id);
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroAttributesExists(attr.hero_id, attr.attribute_id))
                {
                    return NotFound();
                }
                return Conflict();
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/HeroAttribute
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hero_attribute>> PostHeroAttribute(Hero_attribute attr)
        {
          if (_context.HeroAttributes == null)
          {
              return Problem("Entity set 'DBContext.Publishers'  is null.");
          }
            _context.HeroAttributes.Add(attr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeroAttributes", new { hero_id = attr.hero_id, attribute_id = attr.attribute_id }, attr);
        }

        // DELETE: api/HeroAttribute/5
        [HttpDelete("{hero_id} & {attribute_id}")]
        public async Task<IActionResult> DeleteHeroAttribute(int? hero_id, int? attribute_id)
        {
            if (_context.HeroAttributes == null)
            {
                return NotFound();
            }
            var attr = await _context.HeroAttributes.FindAsync(hero_id, attribute_id);
            if (attr == null)
            {
                return NotFound();
            }

            _context.HeroAttributes.Remove(attr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroAttributesExists(int? hero_id, int? attribute_id)
        {
            return (_context.HeroAttributes?.Any(e => (e.hero_id.Equals(hero_id)) && (e.attribute_id.Equals(attribute_id)))).GetValueOrDefault();
        }
    }
}