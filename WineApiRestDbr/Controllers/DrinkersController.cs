using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineApiRest.Model;

namespace WineApiRestDbr
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkersController : ControllerBase
    {
        private readonly WineDbContext _context;

        public DrinkersController(WineDbContext context)
        {
            _context = context;
        }

        // GET: api/Drinkers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drinker>>> GetDrinkers()
        {
            return await _context.Drinkers
                .Include("PreferredWine")
                .ToListAsync();
        }

        // GET: api/Drinkers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drinker>> GetDrinker(int id)
        {
            var drinker = await _context.Drinkers
                .Include("PreferredWine")
                .Where(d => d.Id == id)
                .SingleOrDefaultAsync();
                //.FindAsync(id);

            if (drinker == null)
            {
                return NotFound();
            }

            return drinker;
        }

        // PUT: api/Drinkers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrinker(int id, Drinker drinker)
        {
            if (id != drinker.Id)
            {
                return BadRequest();
            }

            _context.Entry(drinker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkerExists(id))
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

        // POST: api/Drinkers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Drinker>> PostDrinker(Drinker drinker)
        {
            _context.Drinkers.Add(drinker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrinker", new { id = drinker.Id }, drinker);
        }

        // DELETE: api/Drinkers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrinker(int id)
        {
            var drinker = await _context.Drinkers.FindAsync(id);
            if (drinker == null)
            {
                return NotFound();
            }

            _context.Drinkers.Remove(drinker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrinkerExists(int id)
        {
            return _context.Drinkers.Any(e => e.Id == id);
        }
    }
}
