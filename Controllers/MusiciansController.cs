using CrazyMusiciansPractice.Data;
using CrazyMusiciansPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrazyMusiciansPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MusiciansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/musicians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musician>>> GetMusicians()
        {
            return await _context.Musicians.ToListAsync();
        }

        // GET: api/musicians/search?name=John
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Musician>>> SearchMusician([FromQuery] string name)
        {
            return await _context.Musicians
                .Where(m => m.Name.Contains(name))
                .ToListAsync();
        }

        // POST: api/musicians
        [HttpPost]
        public async Task<ActionResult<Musician>> CreateMusician(Musician musician)
        {
            _context.Musicians.Add(musician);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMusicians), new { id = musician.Id }, musician);
        }

        // PUT: api/musicians/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMusician(int id, Musician musician)
        {
            if (id != musician.Id)
            {
                return BadRequest();
            }

            _context.Entry(musician).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Musicians.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // PATCH: api/musicians/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchMusician(int id, [FromBody] string newFeature)
        {
            var musician = await _context.Musicians.FindAsync(id);
            if (musician == null) return NotFound();

            musician.FunnyFeature = newFeature;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/musicians/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusician(int id)
        {
            var musician = await _context.Musicians.FindAsync(id);
            if (musician == null) return NotFound();

            _context.Musicians.Remove(musician);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
