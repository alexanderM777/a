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
    public class OrientacionMedicaController : ControllerBase
    {
        private readonly RegistroClinicoContext _context;

        public OrientacionMedicaController(RegistroClinicoContext context)
        {
            _context = context;
        }

        // GET: api/OrientacionMedica
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrientacionMedica>>> GetOrientacionMedica()
        {
            return await _context.OrientacionMedica.ToListAsync();
        }

        // GET: api/OrientacionMedica/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrientacionMedica>> GetOrientacionMedica(int id)
        {
            var orientacionMedica = await _context.OrientacionMedica.FindAsync(id);

            if (orientacionMedica == null)
            {
                return NotFound();
            }

            return orientacionMedica;
        }

        // PUT: api/OrientacionMedica/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrientacionMedica(int id, OrientacionMedica orientacionMedica)
        {
            if (id != orientacionMedica.OrientacionMedicaID)
            {
                return BadRequest();
            }

            _context.Entry(orientacionMedica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrientacionMedicaExists(id))
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

        // POST: api/OrientacionMedica
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrientacionMedica>> PostOrientacionMedica(OrientacionMedica orientacionMedica)
        {
            _context.OrientacionMedica.Add(orientacionMedica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrientacionMedica", new { id = orientacionMedica.OrientacionMedicaID }, orientacionMedica);
        }

        // DELETE: api/OrientacionMedica/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrientacionMedica(int id)
        {
            var orientacionMedica = await _context.OrientacionMedica.FindAsync(id);
            if (orientacionMedica == null)
            {
                return NotFound();
            }

            _context.OrientacionMedica.Remove(orientacionMedica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrientacionMedicaExists(int id)
        {
            return _context.OrientacionMedica.Any(e => e.OrientacionMedicaID == id);
        }
    }
}
