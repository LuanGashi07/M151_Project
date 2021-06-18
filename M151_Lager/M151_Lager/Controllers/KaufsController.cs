using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using M151_Lager.Data;
using M151_Lager.Modell;

namespace M151_Lager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaufsController : ControllerBase
    {
        private readonly DataContext _context;

        public KaufsController(DataContext context)
        {
            _context = context;
        }

        // PUT: api/Kaufs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKauf(int id, Kauf kauf)
        {
            if (id != kauf.Id)
            {
                return BadRequest();
            }

            _context.Entry(kauf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KaufExists(id))
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

        // POST: api/Kaufs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kauf>> PostKauf(Kauf kauf)
        {
            _context.Kauf.Add(kauf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKauf", new { id = kauf.Id }, kauf);
        }

        // DELETE: api/Kaufs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKauf(int id)
        {
            var kauf = await _context.Kauf.FindAsync(id);
            if (kauf == null)
            {
                return NotFound();
            }

            _context.Kauf.Remove(kauf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KaufExists(int id)
        {
            return _context.Kauf.Any(e => e.Id == id);
        }
    }
}
