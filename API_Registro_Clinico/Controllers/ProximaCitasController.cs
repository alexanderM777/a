using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Registro_Clinico.Data;
using SharedModels;

namespace API_Registro_Clinico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProximaCitasController : ControllerBase
    {
        private readonly RegistroClinicoContext _context;

        public ProximaCitasController(RegistroClinicoContext context)
        {
            _context = context;
        }

        // GET: api/ProximaCitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProximaCita>>> GetProximaCita()
        {
            return await _context.ProximaCita.ToListAsync();
        }

        // GET: api/ProximaCitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProximaCita>> GetProximaCita(int id)
        {
            var proximaCita = await _context.ProximaCita.FindAsync(id);

            if (proximaCita == null)
            {
                return NotFound();
            }

            return proximaCita;
        }

        // PUT: api/ProximaCitas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProximaCita(int id, ProximaCita proximaCita)
        {
            if (id != proximaCita.ProximaCitaID)
            {
                return BadRequest();
            }

            _context.Entry(proximaCita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProximaCitaExists(id))
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

        // POST: api/ProximaCitas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProximaCita>> PostProximaCita(ProximaCita proximaCita)
        {
            _context.ProximaCita.Add(proximaCita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProximaCita", new { id = proximaCita.ProximaCitaID }, proximaCita);
        }

        // DELETE: api/ProximaCitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProximaCita(int id)
        {
            var proximaCita = await _context.ProximaCita.FindAsync(id);
            if (proximaCita == null)
            {
                return NotFound();
            }

            _context.ProximaCita.Remove(proximaCita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProximaCitaExists(int id)
        {
            return _context.ProximaCita.Any(e => e.ProximaCitaID == id);
        }
    }
}
