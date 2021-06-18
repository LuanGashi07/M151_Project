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
    public class PreisController : ControllerBase
    {
        private readonly DataContext _context;

        public PreisController(DataContext context)
        {
            _context = context;
        }
        
        // PUT: api/Preis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreis(int id, Preis preis)
        {
            if (id != preis.Id)
            {
                return BadRequest();
            }

            _context.Entry(preis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreisExists(id))
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

        // POST: api/Preis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Preis>> PostPreis(Preis preis)
        {
            _context.Preis.Add(preis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreis", new { id = preis.Id }, preis);
        }
    }
}
