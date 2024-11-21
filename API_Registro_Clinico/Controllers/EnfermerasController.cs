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
    public class EnfermerasController : ControllerBase
    {
        private readonly RegistroClinicoContext _context;

        public EnfermerasController(RegistroClinicoContext context)
        {
            _context = context;
        }

        // GET: api/Enfermeras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enfermera>>> GetEnfermera()
        {
            return await _context.Enfermera.ToListAsync();
        }

        // GET: api/Enfermeras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enfermera>> GetEnfermera(int id)
        {
            var enfermera = await _context.Enfermera.FindAsync(id);

            if (enfermera == null)
            {
                return NotFound();
            }

            return enfermera;
        }

        // PUT: api/Enfermeras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnfermera(int id, Enfermera enfermera)
        {
            if (id != enfermera.EnfermeraID)
            {
                return BadRequest();
            }

            _context.Entry(enfermera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnfermeraExists(id))
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

        // POST: api/Enfermeras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enfermera>> PostEnfermera(Enfermera enfermera)
        {
            _context.Enfermera.Add(enfermera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnfermera", new { id = enfermera.EnfermeraID }, enfermera);
        }

        // DELETE: api/Enfermeras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnfermera(int id)
        {
            var enfermera = await _context.Enfermera.FindAsync(id);
            if (enfermera == null)
            {
                return NotFound();
            }

            _context.Enfermera.Remove(enfermera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnfermeraExists(int id)
        {
            return _context.Enfermera.Any(e => e.EnfermeraID == id);
        }
    }
}
