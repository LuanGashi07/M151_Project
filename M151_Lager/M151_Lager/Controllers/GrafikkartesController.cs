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
    public class GrafikkartesController : ControllerBase
    {
        private readonly DataContext _context;

        public GrafikkartesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Grafikkartes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grafikkarte>>> GetGrafikkarte()
        {
            return await _context.Grafikkarte.ToListAsync();
        }

        // GET: api/Grafikkartes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grafikkarte>> GetGrafikkarte(int id)
        {
            var grafikkarte = await _context.Grafikkarte.FindAsync(id);

            if (grafikkarte == null)
            {
                return NotFound();
            }

            return grafikkarte;
        }


        // POST: api/Grafikkartes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Grafikkarte>> PostGrafikkarte(Grafikkarte grafikkarte)
        {
            _context.Grafikkarte.Add(grafikkarte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrafikkarte", new { id = grafikkarte.Id }, grafikkarte);
        }

        // DELETE: api/Grafikkartes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrafikkarte(int id)
        {
            var grafikkarte = await _context.Grafikkarte.FindAsync(id);
            if (grafikkarte == null)
            {
                return NotFound();
            }

            _context.Grafikkarte.Remove(grafikkarte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrafikkarteExists(int id)
        {
            return _context.Grafikkarte.Any(e => e.Id == id);
        }
    }
}
